using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    private float f, h;
    // Start is called before the first frame update
    void Start()
    {
   

    }

    // Update is called once per frame
    void Update()
    {
        f = Player.health / 6;
        
            string m = "health"+f.ToString();
        if (gameObject.name== m)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
    }
}
