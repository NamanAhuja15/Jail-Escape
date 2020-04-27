using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthdisplay : MonoBehaviour
{

    public float hp; int i;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        hp = Player.health;

        for (int j = 0; j < 90; j += 6)
        {
            float m = hp / 6;
            string g = m.ToString();

            string l = "image" + g;

        for (i = 90 - (int)hp; i <= 90; i += 6)
            {
                if (i != 0)
                {
                    float k = i / 6;
                    string n = k.ToString();
                    GameObject.Find("health" + n).SetActive(false);
                }
            }

        }
    }


}
