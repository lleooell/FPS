using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class activedoor : MonoBehaviour {
    public Cam c;
    public AudioSource op;
    public Text t;
    float col = 0F;

    bool can_use = false;
    // Use this for initialization
    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {

        if (c.actdoor_used == false && c.hascard == true)
        {
            c.needappeartext = true;
            can_use = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (c.actdoor_used == false && c.hascard == true)
            can_use = true;
    }

    void OnTriggerExit(Collider other)
    {
        c.needappeartext = false;
        can_use = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (can_use == true)
        {
            if (Input.GetKeyDown("e"))
            {
                op.Play();
                c.dooropen = true;
                c.actdoor_used = true;
            }
        }
    }
}
