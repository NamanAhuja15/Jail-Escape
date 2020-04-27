using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Military : MonoBehaviour
{
    public static Vector2 Bulletpos, Bulletdir;
    public Rigidbody2D rb;public static int i;
    public float moveSpeed;
    public static float health;
    private Animator animator;
    private bool Attack, Dead, idle, leftmove, rightmove;
    private bool Move;
    private Vector3 Left, Right;
    public GameObject player, Policebullet,follow;
    public static bool Facingleft, Facingright, detect,pose;
    private float timer = 5f;
    private float MaxDist = 80.0f;
    private float timestamp,f;
    private int count;
    private float timebwattack = 1f;
    private List<GameObject> military;
    public GameObject ammo;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        health = 100.0f;
        animator = GetComponent<Animator>();
        float x = transform.localScale.x;
        float y = transform.localScale.y;
        Left = new Vector3(-x, y, 0);
        Right = new Vector3(x, y,0);
        leftmove = true;
        transform.localScale = Left;
        timestamp = 3f;idle = false;
       
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SpikesLeft"))
        {
            idle = false;
            rightmove = true;
            leftmove = false;


        }
        if (collision.gameObject.CompareTag("SpikesRight"))
        {
            idle = false;
            leftmove = true;
            rightmove = false;


        }
        if(collision.gameObject.CompareTag("Finish"))
        {
            count++;
            Decrease();
        }

        
    }
    void Update()
    {


        animator.SetBool("Move", Move);
        animator.SetBool("Attack", Attack);
        animator.SetBool("Dead", Dead);
        if (!detect)
            CancelInvoke();
        timestamp = Time.deltaTime + timestamp;

        if (count == 10)
            Dead = true;

        if (transform.localScale == Left)
        {
            Facingleft = true;
            Facingright = false;
        }
        else
        {
            Facingright = true;
            Facingleft = false;
        }
        if (!detect)
        {
            Attack = false;
            Move = true;
            if (!leftmove && !rightmove)
            {
                if (player.transform.position.x - gameObject.transform.position.x >= 0f)
                {
                    rightmove = true;
                }
                else
                {
                    leftmove = true;
                }
            }
        }
                
            if (leftmove || rightmove)
            {
                Move = true;
            }

            if (!Dead)
            {
                if (idle)
                {
                    leftmove = false; rightmove = false;
                    rb.velocity = new Vector2(0, 0);
                }
                if (rightmove)
                {
                    transform.localScale = Left;
                    rb.velocity = new Vector2(moveSpeed, 0);
                }
                if (leftmove)
                {
                    transform.localScale = Right;
                    rb.velocity = new Vector2(-moveSpeed, 0);
                    rightmove = false;
                }
            }
        

        if(detect)
        {
            if(Vector2.Distance(gameObject.transform.position,player.transform.position)<=50f)
            {
                Move = false;
                Attack = true;
               rb.velocity = new Vector2(0, 0);
               // idle = true;
                if (player.transform.position.x - transform.position.x > 0)
                {
                    transform.localScale = Left;
                }
                if (player.transform.position.x - transform.position.x <= 0)
                {
                    transform.localScale = Right;
                }
                if (timestamp > timebwattack)
                {
                    InvokeRepeating("Shoot", 0f, 20f);
                }
            }
        }
    }

    public  void Shoot()
    {
        if (timestamp > timebwattack)
        {
            Attack = true;
            timestamp = 0f;
           // Attack = true;
            Bulletpos = transform.position;
            Bulletpos += new Vector2(1.0f, -0.5f);
            Instantiate(Policebullet, Bulletpos, Quaternion.identity);
            Bulletdir = player.transform.position - transform.position;
        }
       

        //count = count + 1;
        //transform.localScale = transform.position - player.transform.position;
    }
    public void Die()
    {
        Instantiate(ammo, transform.position, Quaternion.identity);
        Destroy(follow);
        Destroy(gameObject);
        
    }
    public void Decrease()
    {
        {
            f = (float)count;
            follow.transform.localScale -= new Vector3(f / 2, 0, 0);
            //hit = false;
        }
    }


}
