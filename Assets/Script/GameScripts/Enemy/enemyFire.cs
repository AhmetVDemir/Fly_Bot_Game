using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFire : MonoBehaviour
{
    float carpan = 1;
    
    void Start()
    {
        Destroy(this.gameObject, 3);

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
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.left * (15 * carpan) * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hero")
        {
            Debug.Log("Mermi kahramana çarptı");
            Destroy(gameObject, 0.1f);
        }
    }
}
