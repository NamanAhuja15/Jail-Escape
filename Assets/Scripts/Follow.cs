using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject military;
    private Vector3 offset;
    private float f;public static bool hit;
    void Start()
    {
        offset = transform.position - military.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = military.transform.position + offset;

        }
   

}
