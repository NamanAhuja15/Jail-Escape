using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;private float timestamp;
    public static bool restart;public bool isclose;
    private bool check,close;int n;int count;
    public Sprite on;
    void Start()
    {
        Call.checkpoint.Add(this.gameObject);
        count = 0;
    }
   public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            check = true;
            AddToRange(gameObject);
            gameObject.GetComponent<SpriteRenderer>().sprite = on;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (check)
        {
            isclose = CheckClosest(this.gameObject);
            if (isclose)
            {
                if (restart)
                {
                    player.GetComponent<SpriteRenderer>().enabled = false;

                    Move();
                    restart = false;


                }
            }
        }
    }
    public void AddToRange(GameObject alpha)
    {
        if(Call.checkpoint.Count>=Call.Range.Count)
        {
            Call.Range.Add(alpha);
        }
    }
    public bool CheckClosest(GameObject alpha)
    {
        close = false;
        for(int j=0;j<Call.Range.Count;j++)
        {
            if (alpha != Call.Range[j]) {
                if (Vector2.Distance(player.transform.position, Call.Range[j].transform.position) < Vector2.Distance(player.transform.position, alpha.transform.position))
                    {
                    close = false;
                }
                else
                {
                    close = true;
                }
            }
           if (Call.Range.Count == 1)
            {
                close = true;
            }
        }
        return close;
    }
    public void Move()
    {

            player.transform.position = transform.position;
            player.GetComponent<SpriteRenderer>().enabled = true;
            Player.Alive = true;
 
    }
}
