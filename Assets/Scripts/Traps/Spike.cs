using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public float vel;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void  OnCollisionEnter2D(Collision2D colli)
    {
        if(colli.gameObject.CompareTag("Spikemove"))
            vel = -vel;
        if (colli.gameObject.CompareTag("Ground"))
            vel = -vel;
        }
      
    

    // Update is called once per frame
    void Update()
    {
        if(vel>0)
        transform.Translate(Vector3.up * vel * Time.deltaTime);
        if (vel < 0)
            transform.Translate(Vector3.down *- vel * Time.deltaTime);
    }
}
