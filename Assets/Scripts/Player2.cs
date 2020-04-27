using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2 : MonoBehaviour
{
    public Text objective;
    public GameObject platform;
    private bool confuse;
    // Start is called before the first frame update
    void Start()
    {
        platform.SetActive(false);
        objective.text = "Find clues";
        confuse = true;
    }

    public void OnTriggerEnter2D(Collider2D colli)
    {
        if(colli.gameObject.CompareTag("Door"))
        {
            objective.text = "Find switch";
        }
        if(colli.gameObject.CompareTag("Event"))
        {
            objective.text = "Let's GO!!";
        }
        if(colli.gameObject.CompareTag("1"))
        {
            if(confuse)
            objective.text = "Maybe another way";
        }
        if(colli.gameObject.CompareTag("2"))
        {
            confuse = false;
            platform.SetActive(true);
            objective.text = "Find another way";
        }

    }

}
