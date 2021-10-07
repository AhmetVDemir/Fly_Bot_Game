using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemy : MonoBehaviour
{

    float carpan = 1;

    bool isDead;
    int can = 5;

    

    int zorlukPuani = 5;

    [SerializeField]
    float hiz = 0.5f;

    [SerializeField]
    float atesHizi = 3;

    [SerializeField]
    float uzunluk = 7;

    [SerializeField]
    GameObject enemyMermi;

    [SerializeField]
    Transform atesNoktasi;

    [SerializeField]
    GameObject patlamaNesnesi;

    void hiziAyarla()
    {

        if (PlayerPrefs.GetInt("ZORLUK") == 0)
        {
            hiz = 0.5f * carpan;
            atesHizi = 3f;
            zorlukPuani = 5;
        }
        else if (PlayerPrefs.GetInt("ZORLUK") == 1)
        {
            hiz = 0.9f * carpan;
            atesHizi = 2.7f;
            zorlukPuani = 6;
        }
        else if (PlayerPrefs.GetInt("ZORLUK") == 2)
        {
            hiz = 1.3f * carpan;
            atesHizi = 2f;
            zorlukPuani = 9;
        }
        else if (PlayerPrefs.GetInt("ZORLUK") == 3)
        {
            hiz = 1.6f * carpan;
            atesHizi = 1.7f;
            zorlukPuani = 15;
        }
        else if (PlayerPrefs.GetInt("ZORLUK") == 4)
        {
            hiz = 1.9f * carpan;
            atesHizi = 1.4f;
            zorlukPuani = 18;
        }
        else if (PlayerPrefs.GetInt("ZORLUK") == 5)
        {
            hiz = 2.3f * carpan;
            atesHizi = 1f;
            zorlukPuani = 20;
        }
        else if (PlayerPrefs.GetInt("ZORLUK") == 6)
        {
            hiz = 2.6f * carpan;
            atesHizi = 0.9f;
            zorlukPuani = 23;
        }
        else if (PlayerPrefs.GetInt("ZORLUK") == 7)
        {
            hiz = 2.9f * carpan;
            atesHizi = 0.7f;
            zorlukPuani = 25;
        }
        else if (PlayerPrefs.GetInt("ZORLUK") == 8)
        {
            hiz = 3.3f * carpan;
            atesHizi = 0.5f;
            zorlukPuani = 30;
        }
        else if (PlayerPrefs.GetInt("ZORLUK") == 9)
        {
            hiz = 4f * carpan;
            atesHizi = 0.3f;

            zorlukPuani = 50;
        }
    }

    private void Start()
    {
        StartCoroutine(atesEt());

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


        if (PlayerPrefs.GetInt("ZORLUK") == 0)
            can = 5;

        else if (PlayerPrefs.GetInt("ZORLUK") == 1)
            can = 7;
        else if (PlayerPrefs.GetInt("ZORLUK") == 2)
            can = 9;
        else if (PlayerPrefs.GetInt("ZORLUK") == 3)
            can = 7;
        else if (PlayerPrefs.GetInt("ZORLUK") == 4)
            can = 10;
        else if (PlayerPrefs.GetInt("ZORLUK") == 5)
            can = 14;
        else if (PlayerPrefs.GetInt("ZORLUK") == 6)
            can = 18;
        else if (PlayerPrefs.GetInt("ZORLUK") == 7)
            can = 21;
        else if (PlayerPrefs.GetInt("ZORLUK") == 8)
            can = 25;
        else if (PlayerPrefs.GetInt("ZORLUK") == 9)
            can = 30;

    }

    private void FixedUpdate()
    {
        hiziAyarla();
        hareketEt();
        
    }

    void patlama()
    {
        PlayerPrefs.SetInt("SKR", (PlayerPrefs.GetInt("SKR") + zorlukPuani));
        Instantiate(patlamaNesnesi, this.transform.position, Quaternion.identity);
        gameObject.SetActive(false);
        Destroy(gameObject, 1f);
    }


    IEnumerator atesEt()
    {
        while(isDead == false)
        {
            Instantiate(enemyMermi, atesNoktasi.position, Quaternion.identity);
            yield return new WaitForSeconds(atesHizi);
        }
        
    }
    float x, y, angle = 0f;
    void hareketEt()
    {
        if (this.gameObject.tag == "Enemy")
        {
            transform.position = new Vector3(7, (Mathf.Sin(Time.time * hiz) * uzunluk), -4);
            
        }
        else if(this.gameObject.tag== "LVL2Enemy")
        {
            x = 7.1f + Mathf.Cos(angle) * 5f;
            y = 0.1f + Mathf.Sin(angle) * 5f;
            transform.position = new Vector3(x, y,-4);
            angle = angle + Time.deltaTime * hiz;
            if (angle >= 360f)
                angle = 0;
            
        }
        else if(this.gameObject.tag == "LVL3Enemy")
        {

        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Mermi")
        {
            if (can > 0)
            {
                can -= 1;
            }
            else if (can <= 0)
            {
                PlayerPrefs.SetInt("DEADENEMY", (PlayerPrefs.GetInt("DEADENEMY") + 1));
                
                patlama();                
                Debug.Log("Düşman öldü");
                isDead = true;

                PlayerPrefs.SetInt("ZORLUK", (PlayerPrefs.GetInt("ZORLUK") + 1));
                Debug.Log(PlayerPrefs.GetInt("ZORLUK"));

                PlayerPrefs.SetInt("OLDUMU", 1);
            }
        }
    }
}
