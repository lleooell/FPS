using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class opendoor : MonoBehaviour {
    public Cam c;
    public float state_open = 4f;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (c.dooropen == true)
        {
            if (state_open > 0f)
            {
                transform.localPosition = new Vector3(transform.localPosition.x - 0.1f, transform.localPosition.y, transform.localPosition.z);
                state_open -= 0.1f;
            }
        }
        else
        {
            if (state_open < 4f)
            {
                transform.localPosition = new Vector3(transform.localPosition.x + 0.1f, transform.localPosition.y, transform.localPosition.z);
                state_open += 0.1f;
            }
        }
        
	}
}
