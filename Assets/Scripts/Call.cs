using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Call : MonoBehaviour
{
    public static List<GameObject> checkpoint = new List<GameObject>();
    public  static List<GameObject> Range = new List<GameObject>();
    public GameObject start;
    void Start()
    {
        Range.Add(start);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
