using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boing : MonoBehaviour
{
    private Animator animator;public bool Boingz;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
   void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Boingz = true;

        }
    }

    // Update is called once per frame
    void Update()
    { 
        animator.SetBool("Boing", Boingz);
        //Invoke("Return", 1000f);
    }
    void Return()
    {
        Boingz = false;
    }
}
