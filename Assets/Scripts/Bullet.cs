using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float velx = 80;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (Player.Facingleft)
        {
            rb.velocity = new Vector2(-velx, 0);
        }
        else
        {
            rb.velocity = new Vector2(velx, 0);
        }

    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 2f);
    }
    public void OnTriggerEnter2D(Collider2D colli)
    {
        if(colli.gameObject.CompareTag("Police"))
        {

            Destroy(gameObject);

        }
        if(colli.gameObject.CompareTag("Military"))
        {
            Military.health -= 25.0f;
            Destroy(gameObject);
        }
    }
}
