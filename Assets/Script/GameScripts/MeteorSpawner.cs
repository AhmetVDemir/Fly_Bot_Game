using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    float carpan = 1;

    public Hero heroScrip;

    public GameObject Meteor;

    [SerializeField]
    float uretimAraligi;

    private void Start()
    {
        if(PlayerPrefs.GetInt("LVL") == 1)
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
            

        uretimAraligi = 5f;
        StartCoroutine(SpawnMet());
    }

    private void Update()
    {
        hiziAyarla();
    }

    void hiziAyarla()
    {

        if (PlayerPrefs.GetInt("ZORLUK") == 0)
        {
            uretimAraligi = 5f * carpan;
        }
        else if (PlayerPrefs.GetInt("ZORLUK") == 1)
        {
            uretimAraligi = 4.5f * carpan;
        }
        else if (PlayerPrefs.GetInt("ZORLUK") == 2)
        {
            uretimAraligi = 4f * carpan;
        }
        else if (PlayerPrefs.GetInt("ZORLUK") == 3)
        {
            uretimAraligi = 3.5f * carpan;
        }
        else if (PlayerPrefs.GetInt("ZORLUK") == 4)
        {
            uretimAraligi = 3f * carpan;
        }
        else if (PlayerPrefs.GetInt("ZORLUK") == 5)
        {
            uretimAraligi = 2.5f * carpan;
        }
        else if (PlayerPrefs.GetInt("ZORLUK") == 6)
        {
            uretimAraligi = 2f * carpan;
        }
        else if (PlayerPrefs.GetInt("ZORLUK") == 7)
        {
            uretimAraligi = 1.5f * carpan;
        }
        else if (PlayerPrefs.GetInt("ZORLUK") == 8)
        {
            uretimAraligi = 1f * carpan;
        }
        else if (PlayerPrefs.GetInt("ZORLUK") == 9)
        {
            uretimAraligi = 0.5f * carpan;
        }
    }

    public IEnumerator SpawnMet()
    {
        while (heroScrip.isDead == false)
        {
            

            Instantiate(Meteor, new Vector3(21, Random.Range(-7.63f, 7.21f), -4), Quaternion.identity);

            yield return new WaitForSeconds(uretimAraligi);
        }

       
    }
}
