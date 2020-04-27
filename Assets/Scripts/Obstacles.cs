using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public GameObject Player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
  

    void Update()
    {
        
    }public void OnCollisionEnter2d(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spikes"))
        {
            Destroy(Player);
        }

    }
}
