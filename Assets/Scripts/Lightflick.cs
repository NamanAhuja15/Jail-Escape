using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Lightflick : MonoBehaviour
{

    public Light red, blue;
    private float timestamp;
    // Start is called before the first frame update
    void Start()
    {
        red.enabled = true;
        blue.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        timestamp = timestamp + Time.deltaTime;
        if (red.enabled)
        {
            if (timestamp > 1)
            {
                timestamp = 0f;
                red.enabled = false;
                blue.enabled = true;
            }
        }
        if(blue.enabled)
        {
            if(timestamp>1)
            {
                timestamp = 0;
                blue.enabled = false;
                red.enabled = true;
            }
        }
        
    }
}
