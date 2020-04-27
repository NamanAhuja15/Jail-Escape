using UnityEngine;
using System.Collections;
public class CameraMovement : MonoBehaviour
{

    public GameObject player;

    private Vector3 move;
    public static Vector3 offset;
  //public static bool show;
   //rivate Animator animator;
    void Start()
    {
        
        offset = transform.position - player.transform.position;
        //imator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
       //f (show)
          //transform.position = target.transform.position;
    }
    void LateUpdate()
    {
       //nimator.SetBool("Show", show);
       //f(!show)
        transform.position = player.transform.position + offset;

    }
}