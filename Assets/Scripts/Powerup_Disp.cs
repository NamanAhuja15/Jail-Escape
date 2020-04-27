using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup_Disp : MonoBehaviour
{
    public GameObject  gun;
    private float x,y;
    private GameObject copy, player;

    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player");
        x = player.transform.position.x-1.5f;
        y = player.transform.position.y-4f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.shoot)
        {
            copy = GameObject.Instantiate(gun, new Vector2(x, y), Quaternion.identity);
            Destroy(copy, 1.5f);
        }
    }
}
