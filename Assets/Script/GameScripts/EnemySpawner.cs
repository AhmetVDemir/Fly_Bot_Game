using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject Enemy;

    [SerializeField]
    Transform rotasyon;

    private void Update()
    {

        if (PlayerPrefs.GetInt("OLDUMU") == 1)
        {
            Invoke("canavarUret", 3);
            PlayerPrefs.SetInt("OLDUMU", 0);
        }
    }

    void canavarUret()
    {
        if (PlayerPrefs.GetInt("DEADENEMY") <= 10)
        {

            if (PlayerPrefs.GetInt("LVL") == 3)
            {
                Instantiate(Enemy, new Vector3(Random.Range(10, 17), Random.Range(-7.63f, 7.21f), -4), transform.rotation * Quaternion.Euler(0f, 0f, -90f));
            }
            else
            {
                Instantiate(Enemy, new Vector3(Random.Range(10, 17), Random.Range(-7.63f, 7.21f), -4), Quaternion.identity);
            }

        }
        

    }
}
