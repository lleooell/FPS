using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class avtivate_smoke : MonoBehaviour {
    public Cam c;
    public GameObject rays;
    public AudioSource op;
    bool can_use = false;
    // Use this for initialization
    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (c.smoke_used == false)
        { 
            c.needappeartext = true;
            can_use = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (c.smoke_used == false)
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
                op.Stop();
                c.smoke_activated = true;
                c.smoke_used = true;
                rays.transform.localScale = Vector3.zero;
            }
        }
    }
}
