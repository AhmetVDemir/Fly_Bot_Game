using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    float carpan = 1;

    public GameObject patlama;

    [SerializeField]
    float hiz;

    float yokOlmaZamani = 26;

    private void Start()
    {
        if (PlayerPrefs.GetInt("LVL") == 1)
        {
            carpan = 1;
        }

        else if (PlayerPrefs.GetInt("LVL") == 2)
        {
            carpan = 2;
        }

        else if (PlayerPrefs.GetInt("LVL") == 3)
        {
            carpan = 3;
        }

        hiz = 0.5f;
        Destroy(this.gameObject, yokOlmaZamani);
       
        
    }


    void hiziAyarla()
    {

        if (PlayerPrefs.GetInt("ZORLUK") == 0)
        {
            hiz = 1f * carpan;
            yokOlmaZamani = 26f;
        }
        else if (PlayerPrefs.GetInt("ZORLUK") == 1)
        {
            hiz = 1.5f * carpan;
            yokOlmaZamani = 20f;

        }
        else if (PlayerPrefs.GetInt("ZORLUK") == 2)
        {
            hiz = 2f * carpan;
            yokOlmaZamani = 18f;
        }
        else if (PlayerPrefs.GetInt("ZORLUK") == 3)
        {
            hiz = 2.5f * carpan;
            yokOlmaZamani = 17f;
        }
        else if (PlayerPrefs.GetInt("ZORLUK") == 4)
        {
            hiz = 3f * carpan;
            yokOlmaZamani = 16f;
        }
        else if (PlayerPrefs.GetInt("ZORLUK") == 5)
        {
            hiz = 3.5f * carpan;
            yokOlmaZamani = 15f;
        }
        else if (PlayerPrefs.GetInt("ZORLUK") == 6)
        {
            hiz = 4f * carpan;
            yokOlmaZamani = 13f;

        }
        else if (PlayerPrefs.GetInt("ZORLUK") == 7)
        {
            hiz = 4.5f * carpan;
            yokOlmaZamani = 12f;
        }
        else if (PlayerPrefs.GetInt("ZORLUK") == 8)
        {
            hiz = 5f * carpan;
            yokOlmaZamani = 11f;
        }
        else if (PlayerPrefs.GetInt("ZORLUK") == 9)
        {
            hiz = 5.5f * carpan;
            yokOlmaZamani = 10f;
        }
    }

    void patlamaAnimasyon()
    {
        PlayerPrefs.SetInt("SKR", (PlayerPrefs.GetInt("SKR") + 1));
        Instantiate(patlama, this.transform.position, Quaternion.identity);
        gameObject.SetActive(false);
        Destroy(gameObject, 1f);
        
    }

    [System.Obsolete]
    private void FixedUpdate()
    {
        hiziAyarla();
        transform.position += Vector3.left * hiz * Time.deltaTime;
        transform.Rotate(0.0f, 0.0f, Random.Range(0.0f, 5f), Space.World);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if((collision.gameObject.tag=="Mermi") || (collision.gameObject.tag == "Hero"))
        {
            patlamaAnimasyon();
        }
    }
}
