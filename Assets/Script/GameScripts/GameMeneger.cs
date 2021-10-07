using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMeneger : MonoBehaviour
{
    float carpan = 1;

    [SerializeField]
    Hero heroScrip;

    bool dur = false;

    //can göstergesi için
    public GameObject[] canlar;

    //ses kaynağı kontrolü
    [SerializeField]
    AudioSource sesKaynagi;

    //ses hizi
    [SerializeField]
    float hiz;

    //ölü düşman sayısı
    [SerializeField]
    TMP_Text deadEnemyNum;

    //stop panel objesi
    [SerializeField]
    GameObject stopPanel;

    //stop panel yazısı
    [SerializeField]
    TMP_Text stopPanelYazısı;

    //STOPPanelSkor
    [SerializeField]
    TMP_Text skorStop;


    public void cik()
    {
        PlayerPrefs.SetInt("OLDUMU", 1);
        //herşeyi yeniden başlat
        PlayerPrefs.SetInt("DEADENEMY", 0);
        PlayerPrefs.SetInt("ZORLUK", 0);
        hiz = 1f;
        heroScrip.can = 5;
        PlayerPrefs.SetInt("Can", heroScrip.can);
        canlar[0].SetActive(true);
        canlar[1].SetActive(true);
        canlar[2].SetActive(true);
        canlar[3].SetActive(true);
        canlar[4].SetActive(true);



        SceneManager.LoadScene("2-MenuS");
    }

    public void devam()
    {
        //eğer karakterimiz öldüyse
        if(PlayerPrefs.GetInt("Can") == 0)
        {
            //herşeyi yeniden başlat
            PlayerPrefs.SetInt("DEADENEMY", 0);
            PlayerPrefs.SetInt("ZORLUK", 0);
            hiz = 1f;

            heroScrip.can = 5;
            PlayerPrefs.SetInt("Can", heroScrip.can);

            Debug.Log("Yeni Can : " + heroScrip.can);
            Debug.Log("Yeni prefebs : " + PlayerPrefs.GetInt("Can") );
            canlar[0].SetActive(true);
            canlar[1].SetActive(true);
            canlar[2].SetActive(true);
            canlar[3].SetActive(true);
            canlar[4].SetActive(true);

        }
        if(PlayerPrefs.GetInt("DEADENEMY") == 10)
        {
            if (PlayerPrefs.GetInt("LVL") == 1)
            {
                PlayerPrefs.SetInt("LVL", 2);
                Debug.Log("LVL Set edildi : " + PlayerPrefs.GetInt("LVL"));
                SceneManager.LoadScene("4-LVL2");
            }
            else if (PlayerPrefs.GetInt("LVL") == 2)
            {
                PlayerPrefs.SetInt("LVL", 3);
                Debug.Log("LVL Set edildi : " + PlayerPrefs.GetInt("LVL") + " son level");
                SceneManager.LoadScene("5-LVL3");
            }
            else if (PlayerPrefs.GetInt("LVL") == 3)
            {
                //Tebrikler oyunu bitirdiniz ana menüye dönüp herşeyi sıfırlayarak yeniden başlayabilirsiniz

                SceneManager.LoadScene("2-MenuS");

            }

        }

        // leveli tespip et ve ona göre sonraki sahneye geç

        dur = false;
        sesKaynagi.mute = false;
        stopPanel.SetActive(false);
        Time.timeScale = 1;

    }


    private void Awake()
    {
        stopPanel.SetActive(false);
    }




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

        Time.timeScale = 1;
        PlayerPrefs.SetInt("DEADENEMY", 0);
        PlayerPrefs.SetInt("ZORLUK", 0);
        hiz = 1f;
        
    }

    private void Update()
    {

        //ses hızını ayarla
        hiziAyarla();
        sesKaynagi.pitch = hiz*0.5f;

        canDurumuGostergesi();

        oluDusmanGoster();
        
        if (PlayerPrefs.GetInt("DEADENEMY") == 10)
        {
            Time.timeScale = 0;
            stopPanel.SetActive(true);
            stopPanelYazısı.text = "Tebrikler Level Atladınız !";
            skorStop.text = "Skor : " + PlayerPrefs.GetInt("SKR");
            sesKaynagi.mute = true;
        }
        else if((PlayerPrefs.GetInt("DEADENEMY") == 10) && (PlayerPrefs.GetInt("LVL") == 3))
        {
            Time.timeScale = 0;
            stopPanel.SetActive(true);
            stopPanelYazısı.text = "Tebrikler Oyunu Kazandınız !";
            skorStop.text = "Skor : " + PlayerPrefs.GetInt("SKR");
            sesKaynagi.mute = true;
        }

    }
    public void pauseStop()
    {

        if (dur == false)
        {
            dur = true;
            Time.timeScale = 0;
            sesKaynagi.mute = true;
            stopPanel.SetActive(true);
            skorStop.text = "Skor : " + PlayerPrefs.GetInt("SKR");
        }
        else if (dur == true)
        {
            dur = false;
            sesKaynagi.mute = false;
            stopPanel.SetActive(false);
            Time.timeScale = 1;
        }

    }

    //ses hızını ayarla
    void hiziAyarla()
    {

        if (PlayerPrefs.GetInt("ZORLUK") == 0)
        {
            hiz = 1f * carpan;
            
        }
        else if (PlayerPrefs.GetInt("ZORLUK") == 1)
        {
            hiz = 1.1f * carpan;
        }
        else if (PlayerPrefs.GetInt("ZORLUK") == 2)
        {
            hiz = 1.2f * carpan;
        }
        else if (PlayerPrefs.GetInt("ZORLUK") == 3)
        {
            hiz = 1.3f * carpan;
        }
        else if (PlayerPrefs.GetInt("ZORLUK") == 4)
        {
            hiz = 1.4f * carpan;
        }
        else if (PlayerPrefs.GetInt("ZORLUK") == 5)
        {
            hiz = 1.5f * carpan;
        }
        else if (PlayerPrefs.GetInt("ZORLUK") == 6)
        {
            hiz = 1.6f * carpan;
        }
        else if (PlayerPrefs.GetInt("ZORLUK") == 7)
        {
            hiz = 1.7f * carpan;
        }
        else if (PlayerPrefs.GetInt("ZORLUK") == 8)
        {
            hiz = 1.8f * carpan;
        }
        else if (PlayerPrefs.GetInt("ZORLUK") == 9)
        {
            hiz = 1.9f * carpan;
        }
    }

    

    void oluDusmanGoster()
    {
        deadEnemyNum.text = PlayerPrefs.GetInt("DEADENEMY").ToString();
        
    }

    void canDurumuGostergesi()
    {
        if (PlayerPrefs.GetInt("Can") == 4)
        {
            //5.yi kapa
            canlar[4].SetActive(false);
        }
        else if(PlayerPrefs.GetInt("Can") == 3)
        {
            //4.yü kapa
            canlar[3].SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Can") == 2)
        {
            //3.yü kapa
            canlar[2].SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Can") == 1)
        {
            //2.yi kapa
            canlar[1].SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Can") == 0)
        {
            canlar[0].SetActive(false);
            Time.timeScale = 0;
            stopPanelYazısı.text = "Malesef Öldünüz";

            dur = true;
            sesKaynagi.mute = true;
            stopPanel.SetActive(true);
            skorStop.text = "Skor : " + PlayerPrefs.GetInt("SKR");

        }
    }
}



