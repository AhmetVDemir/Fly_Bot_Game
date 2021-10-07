using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{

    public int can;

    //oyunu finali için
    public bool isDead;

    [SerializeField]
    Rigidbody2D rbBird;

    [SerializeField]
    AudioSource aSource;

    //mermi prefebi
    [SerializeField]
    GameObject bullet;

    //ateş çıkış noktası
    public Transform atesNoktasi;

    public GameObject meteor;




    public float velocity = 6f;


    private void Start()
    {
        can = 5;
        PlayerPrefs.SetInt("Can", can);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fly();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Meteor")||(collision.gameObject.tag == "enemyFire"))
        {
            Debug.Log("Meteor Çarptı");
            if (can >= 0)
            {
                can -= 1;
                PlayerPrefs.SetInt("Can", can);
            }
            if (can <= 0)
            {
                Debug.Log("öldün");
                can -= 1;
                PlayerPrefs.SetInt("Can", 0);
            }
            
        }
    }

    void fly()
    {
        rbBird.velocity = Vector2.up * velocity;
        aSource.Play();
    }

    void atesEt()
    {
        Instantiate(bullet, atesNoktasi.position, Quaternion.identity); 
    }
}
