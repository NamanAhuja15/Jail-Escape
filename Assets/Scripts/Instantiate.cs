using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(SpriteRenderer))]

public class Instantiate : MonoBehaviour
{
    private float width, count;
    private List<GameObject>  list;
   void Start()
    {
        count++;
        var sr=  this.gameObject.GetComponent<SpriteRenderer>();
        width = sr.sprite.rect.width;

            GameObject copy = GameObject.Instantiate(this.gameObject, new Vector2(transform.position.x + width, transform.position.y), Quaternion.identity);
            copy.transform.parent = this.gameObject.transform;
      

    }
    void Update()
    {


    }
}