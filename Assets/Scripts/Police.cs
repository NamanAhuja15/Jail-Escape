using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police : MonoBehaviour
{
    public float moveSpeed;public static bool Hit;
    private Animator animator;
    private bool Attack, idle, leftmove, rightmove;
    private bool Move, Dead, Return;public static bool posed;
    public Vector2 Left, Right;public GameObject player, bumpcheck;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        float x = transform.localScale.x;
        float y = transform.localScale.y;
        Left = new Vector2(-x, y);
        Right = new Vector2(x, y);
        leftmove = true;
        count = 3;
    }
    public void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.CompareTag("SpikesLeft"))
        {
            rightmove = true;
            leftmove = false;
           
            
        }
        if(collider.gameObject.CompareTag("SpikesRight"))
        {
            leftmove = true;
            rightmove = false;
          
            
        }
            if (collider.gameObject.CompareTag("Finish"))
            {
                if (count == 0)
                {
                Dead = true;
                }
                count--;
            }
        }
   /* public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Attack = true;
            leftmove = false;rightmove = false;
            idle = true;
            Player.Alive = false;
        }
    }*/
    void Update()
    {
        animator.SetBool("Attack", Attack);
        animator.SetBool("Dead", Dead);
        animator.SetBool("Move", Move);
        animator.SetBool("Return", Return);
        Return = Player.Alive;
        if (!Dead && !Attack)
        {
            if (leftmove || rightmove)
            {
                Move = true;
            }
            if (rightmove)
            {
                transform.localScale = Left;
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            }
            if (leftmove)
            {
                transform.localScale = Right;
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            }


            if (Vector2.Distance(gameObject.transform.position, player.transform.position) <= 20f)
            {
                Dead = posed;
                if (Dead)
                {
                    gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    Destroy(bumpcheck, 0.2f);
                }
                if (Hit)
                {
                    Attack = true;
                    leftmove = false; rightmove = false;
                    Player.Alive = false;
                }
            }
        }

    }
    public void Die()
    {
        Destroy(bumpcheck);
        Destroy(gameObject);
        Dead = false;
    }


}
