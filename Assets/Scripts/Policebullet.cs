using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Policebullet : MonoBehaviour
{
    private float velx = 80f;
    Rigidbody2D rb;
    private Vector3 Left, Right, moveDirection;
    void Start()
    {
        float x = transform.localScale.x;
        float y = transform.localScale.y;
        Left = new Vector3(x, y, 0);
        Right = new Vector3(-x, y, 0);
        rb = GetComponent<Rigidbody2D>();
        moveDirection = Military.Bulletdir;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * velx * Time.deltaTime;
        if (GameObject.FindGameObjectWithTag("Player").transform.position.x - gameObject.transform.position.x >= 0f)
        {
            transform.localScale = Right;
        }
        else
        {
            transform.localScale = Left;
        }

    }
    void Update()
    {
        Destroy(gameObject, 5f);
    }

    public void OnTriggerEnter2D(Collider2D colli)
    {
        
        if(colli.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
