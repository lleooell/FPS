using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Cam : MonoBehaviour {
    public bool needappeartext = false;
    public RectTransform jauge;
    Vector3 jauge_save;
    public GameObject key;
    public bool actdoor_used = false;
    public bool takecard_used = false;
    public Vector3 savecardsize;
    public bool smoke_used = false;
    public GameObject rays;
    public Light redone;
    public Light redtwo;
    public Light orangeone;
    public Light orangetwo;
    public Light ascone;
    public Light asctwo;
    bool ismoving = false;
    public AudioSource norm_mus;
    public AudioSource panic_mus;
    public AudioSource walk_mus;
    public Text t;

    public RectTransform panelwin;
    Vector3 panelwinsa;
    public RectTransform panelloose;
    Vector3 panelloosesa;
    public RectTransform panelstart;
    Vector3 panelstartsa;



    Color save_redone;
    Color save_redtwo;
    Color save_orangeone;
    Color save_orangetwo;
    Color save_ascone;
    bool onpanicmus = false;
    bool onnarmalmus = false;
    Color save_asctwo;

    public float percent_jauge;

    float clignotement = 0;
    bool go_red = true;


    public bool smoke_activated = false;
    public Vector3 savedrayssclae;
    public bool hascard = false;
    public bool dooropen = false;



    public ParticleSystem particles;
    public ParticleSystem particles2;
    Vector3 save_particles_scale;





    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 1.5F;
    public float sensitivityY = 1.5F;
    public float minimumX = -360F;
    public float maximumX = 360F;
    public float minimumY = -60F;
    public float maximumY = 60F;
    float rotationY = 0F;
    private Vector3 moveDirection = Vector3.zero;
    float speed = 5.0F;
    public CharacterController cc;
    private Vector3 savestart;


    public bool is_in_light = false;
    public bool is_in_cam = false;

    // Use this for initialization
    void Start () {
        savecardsize = key.transform.localScale;
        savedrayssclae = rays.transform.localScale;
        panelwinsa = panelwin.transform.localScale;
        panelloosesa = panelloose.transform.localScale;
        panelstartsa = panelstart.transform.localScale;

        panelstart.transform.localScale = Vector3.zero;
        panelloose.transform.localScale = Vector3.zero;
        panelwin.transform.localScale = Vector3.zero;

        save_redone = redone.color;
        save_redtwo = redtwo.color;
        save_orangeone = orangeone.color;
        save_orangetwo = orangetwo.color;
        save_ascone = ascone.color;
        save_asctwo = asctwo.color;
        t.color = new Color(t.color.r, t.color.g, t.color.b, 0f);

        save_particles_scale = particles.transform.localScale ;
        particles.Stop();
        particles2.Stop();

        savestart = cc.transform.localPosition;


        jauge_save = jauge.transform.localScale;
        jauge.transform.localScale = new Vector3(0f, jauge.transform.localScale.y, jauge.transform.localScale.z);
        StartCoroutine(youstart());

    }
    bool alreadyplaymove = false;
    float col = 0F;

    void Update () {

        if (ismoving == true && alreadyplaymove == false)
        {
            walk_mus.Play();
            alreadyplaymove = true;
        }
        percent_jauge = jauge.transform.localScale.x * 100f / jauge_save.x;
        // move inputs
        if (smoke_activated)
        {
            particles.Play();
            particles2.Play ();
        }
        if (Input.GetKey("w"))
        {
            ismoving = true;
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            cc.Move(moveDirection * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            ismoving = true;
            moveDirection = new Vector3((Input.GetAxis("Horizontal")) * -1F, 0, (Input.GetAxis("Vertical"))) * -1F;
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            cc.Move(moveDirection * Time.deltaTime * -1F);
        }
        if (Input.GetKey("a"))
        {
            ismoving = true;
            moveDirection = new Vector3((Input.GetAxis("Horizontal")) * -1F, 0, 0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            cc.Move(moveDirection * Time.deltaTime * -1F);
        }
        if (Input.GetKey("d"))
        {
            ismoving = true;
            moveDirection = new Vector3((Input.GetAxis("Horizontal")), 0, 0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            cc.Move(moveDirection * Time.deltaTime);
        }
        if (axes == RotationAxes.MouseXAndY)
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        else if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
        }
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
        }
        if (cc.transform.localPosition.y > 1.09F)
            cc.transform.localPosition = new Vector3(cc.transform.localPosition.x, 1.09F, cc.transform.localPosition.z);
        if (Input.GetKeyUp("w") || Input.GetKeyUp("s") || Input.GetKeyUp("a") || Input.GetKeyUp("d"))
        {
            ismoving = false;
            walk_mus.Stop();
            alreadyplaymove = false;
        }
        // move inputs


            // jauge
        if (is_in_light == true && jauge.transform.localScale.x < jauge_save.x)
        {
            jauge.transform.localScale = jauge.transform.localScale + new Vector3(0.0005f, 0f, 0f);
        }
        if (is_in_cam == true && jauge.transform.localScale.x < jauge_save.x)
        {
            if (smoke_activated == true)
                jauge.transform.localScale = jauge.transform.localScale + new Vector3(0.0015f, 0f, 0f);
            else
                jauge.transform.localScale = jauge.transform.localScale + new Vector3(0.003f, 0f, 0f);
        }
		if (is_in_light == false &&  is_in_cam == false && jauge.transform.localScale.x > 0f)
			jauge.transform.localScale = jauge.transform.localScale - new Vector3(0.001f, 0f, 0f);
        if (percent_jauge > 99.9f)
        {
            StartCoroutine(youloose());
            restart("loose");
        }
        if (percent_jauge > 75f)
        {
            onnarmalmus = false;
            if (!onpanicmus)
            {
                panic_mus.Play();
                norm_mus.Stop();
                onpanicmus = true;
            }
            if (go_red == true)
                clignotement += 0.1f;
            else
                clignotement -= 0.1f;
            if (clignotement > 0.99)
                go_red = false;
            else if (clignotement < 0.01)
                go_red = true;
            redone.color = Color.red - new Color(clignotement, 0f, 0f);
            redtwo.color = Color.red - new Color(clignotement, 0f, 0f);
            orangeone.color = Color.red - new Color(clignotement, 0f, 0f);
            orangetwo.color = Color.red - new Color(clignotement, 0f, 0f);
            ascone.color = Color.red - new Color(clignotement, 0f, 0f);
            asctwo.color = Color.red - new Color(clignotement, 0f, 0f);
        }
        else
        {
            onpanicmus = false;
            if (!onnarmalmus)
            {
                norm_mus.Play();
                panic_mus.Stop();
                onnarmalmus = true;
            }
            redone.color = save_redone;
            redtwo.color = save_redtwo;
            orangeone.color = save_orangeone;
            orangetwo.color = save_orangetwo;
            ascone.color = save_ascone;
            asctwo.color = save_asctwo;
        }

        // jauge
        if (needappeartext)
        {
            if (col < 1F)
            {
                t.color = new Color(t.color.r, t.color.g, t.color.b, col);
                col += 0.02F;
            }
        }
        else
        {
            if (col > 0)
            {
                t.color = new Color(t.color.r, t.color.g, t.color.b, col);
                col -= 0.02F;
            }
        }
    }

    public void restart(string u)
    {
        cc.transform.localPosition = savestart;
        jauge.transform.localScale = new Vector3(0f, jauge.transform.localScale.y, jauge.transform.localScale.z);
        particles.Stop ();
        particles2.Stop ();
        actdoor_used = false;
        takecard_used = false;
        smoke_used = false;
        key.transform.localScale = savecardsize;
        rays.transform.localScale = savedrayssclae;
        smoke_activated = false;
        dooropen = false;
    }

    public IEnumerator youwin()
    {
        panelwin.transform.localScale = panelwinsa;
        yield return new WaitForSeconds(3);
        panelwin.transform.localScale = Vector3.zero;
        StartCoroutine(youstart());
    }

    IEnumerator youloose()
    {
        panelloose.transform.localScale = panelloosesa;
        yield return new WaitForSeconds(3);
        panelloose.transform.localScale = Vector3.zero;
        StartCoroutine(youstart());
    }

    IEnumerator youstart()
    {
        panelstart.transform.localScale = panelstartsa;
        yield return new WaitForSeconds(2);
        panelstart.transform.localScale = Vector3.zero;
    }
}
