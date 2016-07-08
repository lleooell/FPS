using UnityEngine;
using System.Collections;

public class Inlight : MonoBehaviour {
    public Cam c;
	// Use this for initialization
	void Start () {
	
	}
    void OnTriggerEnter(Collider other)
    {
        c.is_in_light = true;
    }

    void OnTriggerStay(Collider other)
    {
        c.is_in_light = true;
    }

    void OnTriggerExit(Collider other)
    {
        c.is_in_light = false;
    }
    // Update is called once per frame
    void Update () {
	
	}
}
