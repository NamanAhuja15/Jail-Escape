using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    public static bool Lock,Clear;public Sprite Open;
    public Sprite Unlocked, Locked;
    void Start()
    {
        Lock = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Lock)
            gameObject.GetComponent<SpriteRenderer>().sprite = Locked;
        if (!Lock)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Unlocked;
        }
        if(Clear)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Open;
        }
    }
}
