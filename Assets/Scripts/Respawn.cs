using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Respawn : MonoBehaviour
{
    public GameObject restart;
    public Camera Camera1;
    public GameObject player;
    void Start()
    {
        restart.SetActive(false);
    }
   public void OnClick()
    {
        Checkpoint.restart = true;
        restart.SetActive(false);
        Player.Alive = true;
        Player.health = 100;
        Camera1.transform.position = player.transform.position + CameraMovement.offset;
        Player.lives--;

    }

}
