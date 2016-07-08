using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class secu : MonoBehaviour {
    public Cam c;
    // Use this for initialization
    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        c.is_in_cam = true;
        c.is_in_light = false;
    }

    void OnTriggerStay(Collider other)
    {
        c.is_in_cam = true;
        c.is_in_light = false;
    }

    void OnTriggerExit(Collider other)
    {
        c.is_in_cam = false;
        c.is_in_light = false;
    }
    // Update is called once per frame
    void Update()
    {

    }
}