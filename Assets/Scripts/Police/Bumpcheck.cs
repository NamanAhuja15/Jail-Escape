using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumpcheck : MonoBehaviour
{
    public GameObject military;
    private float x, y;
    private Vector2 offset, newpos;
    void Start()
    {
        offset = military.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        newpos = new Vector2(military.transform.position.x - offset.x, military.transform.position.y - offset.y);
        transform.position = newpos;
    }
}
