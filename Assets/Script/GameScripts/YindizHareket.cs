using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YindizHareket : MonoBehaviour
{
    [SerializeField]
    float carpan = 1;

    [SerializeField]
    float hiz;

    private void Start()
    {
        if (PlayerPrefs.GetInt("LVL") == 1)
            carpan = 1;
        else if (PlayerPrefs.GetInt("LVL") == 2)
            carpan = 2;
        else if (PlayerPrefs.GetInt("LVL") == 3)
            carpan = 3;

        hiz = 0.5f;
    }

    void hiziAyarla()
    {
        
        if (PlayerPrefs.GetInt("ZORLUK") == 0)
        {
            hiz = 0.5f * carpan;
        }
        else if (PlayerPrefs.GetInt("ZORLUK") == 1)
        {
            hiz = 1f * carpan;
        }
        else if (PlayerPrefs.GetInt("ZORLUK") == 2)
        {
            hiz = 1.5f * carpan;
        }
        else if (PlayerPrefs.GetInt("ZORLUK") == 3)
        {
            hiz = 2f * carpan;
        }
        else if (PlayerPrefs.GetInt("ZORLUK") == 4)
        {
            hiz = 2.5f * carpan;
        }
        else if (PlayerPrefs.GetInt("ZORLUK") == 5)
        {
            hiz = 3f * carpan;
        }
        else if (PlayerPrefs.GetInt("ZORLUK") == 6)
        {
            hiz = 3.5f * carpan;
        }
        else if (PlayerPrefs.GetInt("ZORLUK") == 7)
        {
            hiz = 4f * carpan;
        }
        else if (PlayerPrefs.GetInt("ZORLUK") == 8)
        {
            hiz = 4.5f * carpan;
        }
        else if (PlayerPrefs.GetInt("ZORLUK") == 9)
        {
            hiz = 5f * carpan;
        }
    }

    private void FixedUpdate()
    {
        hiziAyarla();

        transform.position += Vector3.left * hiz * Time.deltaTime;
        if (gameObject.transform.position.x <= -41)
        {
            gameObject.transform.position = new Vector3(40, 8.6f, -4);
        }
    }


}
