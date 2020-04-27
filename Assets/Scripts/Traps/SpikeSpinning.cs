using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSpinning : MonoBehaviour
{
    public float vel;

    // Start is called before the first frame update
    void Start()
    {

    }
    public void OnTriggerEnter2D(Collider2D colli)
    {
        if (colli.gameObject.CompareTag("Spikemove"))
            vel = -vel;
        if (colli.gameObject.CompareTag("Ground"))
            vel = -vel;
    }



    // Update is called once per frame
    void Update()
    {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(vel, 0);
    }
}
