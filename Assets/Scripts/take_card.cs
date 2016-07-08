using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class take_card : MonoBehaviour {
    public Cam c;
    public GameObject key;
    public AudioSource takemus;
    bool can_use = false;
    // Use this for initialization
    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (c.takecard_used == false)
        {
            c.needappeartext = true;
            can_use = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (c.takecard_used == false)
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
                takemus.Play();
                c.hascard = true;
                c.takecard_used = true;
                key.transform.localScale = Vector3.zero;
            }
        }
    }
}
