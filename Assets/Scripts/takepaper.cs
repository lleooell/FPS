using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class takepaper : MonoBehaviour {
    public Cam c;
    public AudioSource op;
    bool can_use = false;
    // Use this for initialization
    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        c.needappeartext = true;
        can_use = true;
    }

    void OnTriggerStay(Collider other)
    {
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
                StartCoroutine(c.youwin());
                c.restart("win");
            }
        }
    }
}
