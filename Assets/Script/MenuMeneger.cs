using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuMeneger : MonoBehaviour
{

    [SerializeField]
    TMP_Text skr;

    [SerializeField]
    TMP_Text Lvl;

    [SerializeField]
    GameObject resetAllPanel;

    private void Awake()
    {
        if ((PlayerPrefs.GetInt("LVL") == null) || (PlayerPrefs.GetInt("LVL") == 0))
        {
            PlayerPrefs.SetInt("LVL", 1);
            Debug.Log("LVL Set edildi : " + PlayerPrefs.GetInt("LVL"));
        }
        
    }

    private void Start()
    {
        
        resetAllPanel.SetActive(false);
        
        skr.text = PlayerPrefs.GetInt("SKR") != 0 ? PlayerPrefs.GetInt("SKR").ToString() : "0";

        Lvl.text = PlayerPrefs.GetInt("LVL").ToString();
    }

    public void basla()
    {
        if(PlayerPrefs.GetInt("LVL") == 1)
        {

            SceneManager.LoadScene("3-GameSceene");

        }else if(PlayerPrefs.GetInt("LVL") == 2)
        {
            SceneManager.LoadScene("4-LVL2");
        }else if(PlayerPrefs.GetInt("LVL") == 3)
        {
            SceneManager.LoadScene("5-LVL3");
        }
    }

    public void cikis()
    {
        Application.Quit();
    }

    public void resetPanelAc()
    {
        resetAllPanel.SetActive(true);
    }

    public void herseyiResetle()
    {
        PlayerPrefs.SetInt("LVL", 1);
        PlayerPrefs.SetInt("DEADENEMY", 0);
        PlayerPrefs.SetInt("ZORLUK", 0);
        PlayerPrefs.SetInt("SKR", 0);
        resetAllPanel.SetActive(false);
        Debug.Log("Resetleme başarılı");
        Lvl.text = PlayerPrefs.GetInt("LVL").ToString();
    }

    public void vazgec()
    {
        resetAllPanel.SetActive(false);
    }


}
