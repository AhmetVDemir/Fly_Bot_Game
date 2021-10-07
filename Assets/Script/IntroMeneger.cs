using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroMeneger : MonoBehaviour
{
    
    void Start()
    {

        Invoke("LS", 2.9f);
        
        
    }


    public void LS()
    {
        SceneManager.LoadScene("2-MenuS");
    }
}
