using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
   public void Click()
    {
        SceneManager.LoadScene("Level0");

    }
    public void Quit()
    {
        Application.Quit();
    }

}
