using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed, maxvelocity;
    public new Rigidbody2D rigidbody;
    private Vector3 Left, Right,leftz,rightz;
    private Vector2 Bulletpos;
    public float initialJumpForce, firerate, climbspeed;
    private bool playerJumped, DoubleJumped, isGrounded,climbing;
    private float originalspeed, fall, timestamp, timebwattack, hp;
    public static bool Alive = true;
    private bool Running = false;
    public static bool PoliceDead,shoot = false;
    private bool candoublejump,gun,ak;
    public  static bool Facingleft, Facingright,boing;
    public static bool Hit = false;
    public GameObject Bullet, Gun, AK, restart;
    public static float health;int i;
    private GameObject copy;public int count,guncount,akcount;public Text bullets,op,LockStatus,life, Event;public Image pistol, rifle;
    private Animator animator;
   public static int lives;
    private AudioSource audioSource;
    private void Start()
    {
        lives = 3;
        float x = transform.localScale.x;
        float y = transform.localScale.y;
        Left = new Vector3(-x, y, 1);
        Right = new Vector3(x, y, 1);
        originalspeed = moveSpeed;

        animator = GetComponent<Animator>();
        health = 100;
        count = 5;
        gun = true;Event.enabled = false;
        guncount = 5;
        akcount = 10;
        pistol.enabled = false;LockStatus.enabled = false;
        rifle.enabled = false;
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            playerJumped = false;
            DoubleJumped = false;
            moveSpeed = originalspeed;
            isGrounded = true;
            boing = false;
            rigidbody.gravityScale = 2.8f;
        }
        if(collision.gameObject.CompareTag("Health"))
        {
            health += 50f;
            Destroy(collision.gameObject);
        }
      //  if(collision.gameObject.CompareTag("Water"))
       // {
       //     isWater = true;
        //    moveSpeed = originalspeed / 1.5f;
       // }

        if(collision.gameObject.CompareTag("Police"))
        {
            if (collision.collider.GetType() == typeof(BoxCollider2D))
            {
                Police.Hit = true;
                health = 0f;
                Alive = false;
            }

        }
        if(collision.gameObject.CompareTag("Bump"))
        {
            Debug.Log("ok");
                Police.posed = true;
            Destroy(collision.gameObject, 0.4f);
                DoubleJump();
            
        }
        if (collision.gameObject.CompareTag("Boing"))
        {
            boing = true;
            DoubleJump();
        }
        if (collision.gameObject.CompareTag("Spikes"))
        {
            health = 0;Alive = false;
            rigidbody.gravityScale *= 3f;
            // GameManager.gameOver(gameObject);
        }

    }
 
    public void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            moveSpeed = moveSpeed / 2.0f;
            isGrounded = false;
        }
     //   if(collision.gameObject.CompareTag("Water"))
       // {
       //     isWater = false;
       //     moveSpeed = moveSpeed / 2.0f;

     //   }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Boing"))
        {
            boing = true;
            DoubleJump();
        }
        if (collision.gameObject.CompareTag("Spikes"))
        {
            health = 0f;
            rigidbody.gravityScale *= 3f;
            // GameManager.gameOver(gameObject);
        }
        if (collision.gameObject.CompareTag("Ladder"))
        {
            climbing = true;playerJumped = true;
           
            if(Input.GetKey(KeyCode.W))
            {
                rigidbody.velocity = new Vector2(0, climbspeed);
            }
            if(Input.GetKey(KeyCode.S))
            {
                rigidbody.velocity = new Vector2(0, -climbspeed);
            }
          // rigidbody.gravityScale = 1f;
        }

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Event"))
        {
            Event.enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                Events.Lock = false;
            }
        }
        if(collision.gameObject.CompareTag("Door"))
        {
            if(!Events.Lock)
            Events.Clear = true;
            Invoke("NextScene", 3f);

            if (Events.Lock)
                LockStatus.enabled = true;
        }
        if(collision.gameObject.CompareTag("PistolAmmo"))
        {
            guncount += 10;
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.CompareTag("GunAmmo"))
        {
            akcount += 10;
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.CompareTag("Acid"))
        {
            Player.Alive = false;
            health = 0f;
            rigidbody.gravityScale = 5f;
        }
        if(collision.gameObject.CompareTag("EditorOnly"))
        {
            health = health - 10f;
            Destroy(collision.gameObject);
        }
    }

        public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            climbing = false;
            DoubleJumped = true;
            //rigidbody.AddForce(new Vector2(0, initialJumpForce / 2));
        }
        if(collision.gameObject.CompareTag("Event"))
        {
            Event.enabled = false;
        }
        if (collision.gameObject.CompareTag("Door"))
        {
            Events.Clear = false ;
                LockStatus.enabled = false;
        }
        // rigidbody.gravityScale = 1f;
    }
    void Update()
    {
        op.text = health.ToString();

        if(lives==0)
        {
            SceneManager.LoadScene("GameOver");
        }
        life.text = lives.ToString();
        if (gun)
            {
                timebwattack = 1f;
                count = guncount;
                pistol.enabled = true;
                rifle.enabled = false;
            }
            if (ak)
            {
                timebwattack = 0.5f;
                count = akcount;
                rifle.enabled = true;
                pistol.enabled = false;

            }
            if (health < 1f)
                Alive = false;
            if (health > 100f)
                health = 100f;
            if (health < 0f)
                health = 0f;
            if (health > 1f)
                Alive = true;
            timestamp = timestamp + Time.deltaTime;
            bullets.text = count.ToString();
            
            animator.speed = 5f;

            animator.SetBool("Alive", Alive);
            animator.SetBool("Running", Running);
            animator.SetBool("Jumped", playerJumped);
            animator.SetBool("DoubleJump", DoubleJumped);
            animator.SetBool("Grounded", isGrounded);
            if (transform.localScale == Left)
            {
                Facingleft = true;
                Facingright = false;
                i = -1;
            }
            else
            {
                Facingright = true;
                Facingleft = false;
                i = 1;
            }
            if (rigidbody.velocity == new Vector2(0, 0))
            {
                Running = false;
            }

            if (rigidbody.velocity.x > maxvelocity)
            {
                rigidbody.velocity = new Vector2(maxvelocity, rigidbody.velocity.y);
            }



        if (Alive)
        {
            if (Input.GetKey(KeyCode.D))
            {
                if (!climbing)
                {
                    if (isGrounded)
                    {
                        Running = true;
                    }
                    transform.localScale = Right;
                    transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
                    Facingleft = false;
                    Facingright = true;
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                gun = true;
                ak = false;
                count = guncount;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                gun = false;
                ak = true;
                count = akcount;
            }

            if (Input.GetKey(KeyCode.A))
            {
                if (!climbing)
                {
                    if (isGrounded)
                    {
                        Running = true;
                    }
                    transform.localScale = Left;
                    transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
                }


            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isGrounded)

                {
                   
                    Invoke("Fall", 1f);
                    playerJumped = true;
                    rigidbody.velocity = new Vector2(0, 0);
                    rigidbody.AddForce(transform.TransformDirection(Vector3.up) * initialJumpForce);

                    candoublejump = true;
                }
                else
                {
                    if (candoublejump)
                    {
                        DoubleJump();

                    }

                }
                /* if (isWater)
                 * 
                 * 
                 {
                     rigidbody.velocity = new Vector2(0, 0);
                     rigidbody.AddForce(new Vector2(0, initialJumpForce / 1.5f));
                 }*/
                if (boing)
                {
                    Invoke("DoubleJump", 0.4f);
                }
            }
            if (Event.enabled == true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Events.Lock = false;
                }
            }
        }

            
    }
    void LateUpdate()
    {
        if (Alive)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (timestamp > timebwattack)
                {
                    if (count > 0)
                    {
                        timestamp = 0f;
                        float i = 1;
                        if (Facingleft)
                            i = -1f;
                        if (Facingright)
                            i = 1f;

                        if (gun)
                        {
                            copy = Instantiate(Gun, new Vector2(transform.position.x + (i * 6f), transform.position.y - 4f), Quaternion.identity);
                        }
                        if (ak)
                        {
                            copy = Instantiate(AK, new Vector2(transform.position.x + (i * 6f), transform.position.y - 4f), Quaternion.identity);
                        }
                        Bulletpos = copy.transform.position;
                        Bulletpos += new Vector2(i * 2f, 1f);
                        Instantiate(Bullet, Bulletpos, Quaternion.identity);
                        float a = copy.transform.localScale.x;
                        float b = copy.transform.localScale.y;
                        leftz = new Vector3(-a, b, 0);
                        rightz = new Vector3(a, b, 0);
                        if (Facingleft)
                            copy.transform.localScale = leftz;
                        if (Facingright)
                            copy.transform.localScale = rightz;
                        Destroy(copy, 0.5f);
                        if (gun)
                            guncount--;
                        if (ak)
                            akcount--;
                    }
                }
            }
        }
    }
    public void DoubleJump()
    {
        rigidbody.gravityScale = 1f;
        DoubleJumped = true;
        playerJumped = false;
        candoublejump = false;
        rigidbody.velocity = new Vector2(0, 0);
       if (boing)
        { fall = 1.5f; }
       else { fall = 1f; }
        rigidbody.AddForce(transform.TransformDirection(Vector3.up) * initialJumpForce * fall) ;
            Invoke("Fall", 0.5f);

    }
   /* public void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
            {
            Instantiate(Bullet);
        }
    }*/
    public void Fall()
    {
        if(DoubleJumped)
        rigidbody.gravityScale *= 4.5f;
       // if (playerJumped)
         //   rigidbody.gravityScale *= 2f;
    }
    public void Die()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        restart.SetActive(true);
        Player.Alive = false;
    }
    public void NextScene()
    {
        // Scene scene= SceneManager.GetSceneByName("Level1");
        SceneManager.LoadScene("Level1");
        //DontDestroyOnLoad(gameObject);
       // SceneManager.MoveGameObjectToScene(gameObject, scene);
       // gameObject.transform.position = new Vector3(0, 0, 0);
    }



}

    



