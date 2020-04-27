using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercheck : MonoBehaviour
{
    private List<GameObject> checks; public static  int count;
    public void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            //GetComponent<BoxCollider2D>().enabled = true;
            Military.detect = true;
          
        }

    }
    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            // GetComponent<BoxCollider2D>().enabled = true;
            Military.detect = false;
        }
    }
    void Start()
    {
    }
    void Update()
    {
       
        
    }
    public void Checkindex(GameObject alpha)

    {
        for (int j = 0; j < checks.Count; j++)
        {
            if (checks[j] == alpha)
            {
                j = count;
            }
        }
    }
}
