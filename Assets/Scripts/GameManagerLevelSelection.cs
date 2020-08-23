using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerLevelSelection : MonoBehaviour
{
    private AudioSource mainMenuMusic;
    public GameObject button01;
    public GameObject button02;
    public GameObject button03;
    public GameObject button04;
    public GameObject button05;
    public GameObject button06;
    public GameObject button07;
    public GameObject button08;
    public GameObject button09;
    public GameObject button10;
    public GameObject button11;
    public GameObject button12;
    public GameObject button13;
    public GameObject button14;
    public GameObject button15;
    public GameObject button16;
    [SerializeField] private TMPro.TMP_Text playerPongoCoinBalanceText;
    [SerializeField] private TMPro.TMP_Text levelCoinValue1;
    [SerializeField] private TMPro.TMP_Text levelCoinValue2;
    [SerializeField] private TMPro.TMP_Text levelCoinValue3;
    [SerializeField] private TMPro.TMP_Text levelCoinValue4;
    [SerializeField] private TMPro.TMP_Text levelCoinValue5;
    [SerializeField] private TMPro.TMP_Text levelCoinValue6;
    [SerializeField] private TMPro.TMP_Text levelCoinValue7;
    [SerializeField] private TMPro.TMP_Text levelCoinValue8;
    [SerializeField] private TMPro.TMP_Text levelCoinValue9;
    [SerializeField] private TMPro.TMP_Text levelCoinValue10;
    [SerializeField] private TMPro.TMP_Text levelCoinValue11;
    [SerializeField] private TMPro.TMP_Text levelCoinValue12;
    [SerializeField] private TMPro.TMP_Text levelCoinValue13;
    [SerializeField] private TMPro.TMP_Text levelCoinValue14;
    [SerializeField] private TMPro.TMP_Text levelCoinValue15;
    [SerializeField] private TMPro.TMP_Text levelCoinValue16;
    // Start is called before the first frame update
    void Start()
    {
        mainMenuMusic = GameObject.FindGameObjectWithTag("main_menu_music_tag")?.GetComponent<AudioSource>();
        
        button02.SetActive(false);
        button03.SetActive(false);
        button04.SetActive(false);
        button05.SetActive(false);
        button06.SetActive(false);
        button07.SetActive(false);
        button08.SetActive(false);
        button09.SetActive(false);
        button10.SetActive(false);
        button11.SetActive(false);
        button12.SetActive(false);
        button13.SetActive(false);
        button14.SetActive(false);
        button15.SetActive(false);
        button16.SetActive(false);

        //GameObject[] levelButtons = GameObject.FindGameObjectsWithTag("level_button_tag");
        //levelButtons[0].SetActive(true);
        //levelButtons[1].SetActive(false);
        //levelButtons[2].SetActive(false);
        //levelButtons[3].SetActive(false);
        //levelButtons[4].SetActive(false);
        //levelButtons[5].SetActive(false);
        //levelButtons[6].SetActive(false);
        //levelButtons[7].SetActive(false);

        int maxLevel = PlayerPrefs.GetInt("MaxLevelReached", -1);
        switch (maxLevel)
        {
            case -1:
                button01.SetActive(true); // prob don't need this
                break;
            case 2:
                button02.SetActive(true);
                break;
            case 3:
                button02.SetActive(true);
                button03.SetActive(true);
                break;
            case 4:
                button02.SetActive(true);
                button03.SetActive(true);
                button04.SetActive(true);
                break;
            case 5:
                button02.SetActive(true);
                button03.SetActive(true);
                button04.SetActive(true);
                button05.SetActive(true);
                break;
            case 6:
                button02.SetActive(true);
                button03.SetActive(true);
                button04.SetActive(true);
                button05.SetActive(true);
                button06.SetActive(true);
                break;
            case 7:
                button02.SetActive(true);
                button03.SetActive(true);
                button04.SetActive(true);
                button05.SetActive(true);
                button06.SetActive(true);
                button07.SetActive(true);
                break;
            case 8:
                button02.SetActive(true);
                button03.SetActive(true);
                button04.SetActive(true);
                button05.SetActive(true);
                button06.SetActive(true);
                button07.SetActive(true);
                button08.SetActive(true);
                break;
            case 9:
                button02.SetActive(true);
                button03.SetActive(true);
                button04.SetActive(true);
                button05.SetActive(true);
                button06.SetActive(true);
                button07.SetActive(true);
                button08.SetActive(true);
                //button09.SetActive(true);
                break;
            case 10:
                button02.SetActive(true);
                button03.SetActive(true);
                button04.SetActive(true);
                button05.SetActive(true);
                button06.SetActive(true);
                button07.SetActive(true);
                button08.SetActive(true);
                button09.SetActive(true);
                button10.SetActive(true);
                break;
            case 11:
                button02.SetActive(true);
                button03.SetActive(true);
                button04.SetActive(true);
                button05.SetActive(true);
                button06.SetActive(true);
                button07.SetActive(true);
                button08.SetActive(true);
                button09.SetActive(true);
                button10.SetActive(true);
                button11.SetActive(true);
                break;
            case 12:
                button02.SetActive(true);
                button03.SetActive(true);
                button04.SetActive(true);
                button05.SetActive(true);
                button06.SetActive(true);
                button07.SetActive(true);
                button08.SetActive(true);
                button09.SetActive(true);
                button10.SetActive(true);
                button11.SetActive(true);
                button12.SetActive(true);
                break;
            case 13:
                button02.SetActive(true);
                button03.SetActive(true);
                button04.SetActive(true);
                button05.SetActive(true);
                button06.SetActive(true);
                button07.SetActive(true);
                button08.SetActive(true);
                button09.SetActive(true);
                button10.SetActive(true);
                button11.SetActive(true);
                button12.SetActive(true);
                button13.SetActive(true);
                break;
            case 14:
                button02.SetActive(true);
                button03.SetActive(true);
                button04.SetActive(true);
                button05.SetActive(true);
                button06.SetActive(true);
                button07.SetActive(true);
                button08.SetActive(true);
                button09.SetActive(true);
                button10.SetActive(true);
                button11.SetActive(true);
                button12.SetActive(true);
                button13.SetActive(true);
                button14.SetActive(true);
                break;
            case 15:
                button02.SetActive(true);
                button03.SetActive(true);
                button04.SetActive(true);
                button05.SetActive(true);
                button06.SetActive(true);
                button07.SetActive(true);
                button08.SetActive(true);
                button09.SetActive(true);
                button10.SetActive(true);
                button11.SetActive(true);
                button12.SetActive(true);
                button13.SetActive(true);
                button14.SetActive(true);
                button15.SetActive(true);
                break;
            case 16:
                button02.SetActive(true);
                button03.SetActive(true);
                button04.SetActive(true);
                button05.SetActive(true);
                button06.SetActive(true);
                button07.SetActive(true);
                button08.SetActive(true);
                button09.SetActive(true);
                button10.SetActive(true);
                button11.SetActive(true);
                button12.SetActive(true);
                button13.SetActive(true);
                button14.SetActive(true);
                button15.SetActive(true);
                button16.SetActive(true);
                break;
        }


        SetLevelValueText();
        playerPongoCoinBalanceText.text = PongoCoinManager.GetBalance().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLevelValueText()
    {
        levelCoinValue1.text = PongoCoinManager.PongoCoinsForScene("Level01").ToString();
        levelCoinValue2.text = PongoCoinManager.PongoCoinsForScene("Level02").ToString();
        levelCoinValue3.text = PongoCoinManager.PongoCoinsForScene("Level03").ToString();
        levelCoinValue4.text = PongoCoinManager.PongoCoinsForScene("Level04").ToString();
        levelCoinValue5.text = PongoCoinManager.PongoCoinsForScene("Level05").ToString();
        levelCoinValue6.text = PongoCoinManager.PongoCoinsForScene("Level06").ToString();
        levelCoinValue7.text = PongoCoinManager.PongoCoinsForScene("Level07").ToString();
        levelCoinValue8.text = PongoCoinManager.PongoCoinsForScene("Level08").ToString();
        levelCoinValue9.text = PongoCoinManager.PongoCoinsForScene("Level09").ToString();
        levelCoinValue10.text = PongoCoinManager.PongoCoinsForScene("Level10").ToString();
        levelCoinValue11.text = PongoCoinManager.PongoCoinsForScene("Level11").ToString();
        levelCoinValue12.text = PongoCoinManager.PongoCoinsForScene("Level12").ToString();
        levelCoinValue13.text = PongoCoinManager.PongoCoinsForScene("Level13").ToString();
        levelCoinValue14.text = PongoCoinManager.PongoCoinsForScene("Level14").ToString();
        levelCoinValue15.text = PongoCoinManager.PongoCoinsForScene("Level15").ToString();
        levelCoinValue16.text = PongoCoinManager.PongoCoinsForScene("Level16").ToString();
    }

    public void OnClickLevel01Button()
    {
        mainMenuMusic?.Stop();
        SceneManager.LoadScene("Level01");
    }
    public void OnClickLevel02Button()
    {
        mainMenuMusic?.Stop();
        SceneManager.LoadScene("Level02");
    }
    public void OnClickLevel03Button()
    {
        mainMenuMusic?.Stop();
        SceneManager.LoadScene("Level03");
    }
    public void OnClickLevel04Button()
    {
        mainMenuMusic?.Stop();
        SceneManager.LoadScene("Level04");
    }
    public void OnClickLevel05Button()
    {
        mainMenuMusic?.Stop();
        SceneManager.LoadScene("Level05");
    }
    public void OnClickLevel06Button()
    {
        mainMenuMusic?.Stop();
        SceneManager.LoadScene("Level06");
    }
    public void OnClickLevel07Button()
    {
        mainMenuMusic?.Stop();
        SceneManager.LoadScene("Level07");
    }
    public void OnClickLevel08Button()
    {
        mainMenuMusic?.Stop();
        SceneManager.LoadScene("Level08");
    }public void OnClickLevel09Button()
    {
        mainMenuMusic?.Stop();
        SceneManager.LoadScene("Level09");
    }public void OnClickLevel10Button()
    {
        mainMenuMusic?.Stop();
        SceneManager.LoadScene("Level08");
    }public void OnClickLevel11Button()
    {
        mainMenuMusic?.Stop();
        SceneManager.LoadScene("Level11");
    }public void OnClickLevel12Button()
    {
        mainMenuMusic?.Stop();
        SceneManager.LoadScene("Level12");
    }public void OnClickLevel13Button()
    {
        mainMenuMusic?.Stop();
        SceneManager.LoadScene("Level13");
    }public void OnClickLevel14Button()
    {
        mainMenuMusic?.Stop();
        SceneManager.LoadScene("Level14");
    }public void OnClickLevel15Button()
    {
        mainMenuMusic?.Stop();
        SceneManager.LoadScene("Level15");
    }public void OnClickLevel16Button()
    {
        mainMenuMusic?.Stop();
        SceneManager.LoadScene("Level16");
    }

    public void OnClickSettingsButton()
    {
        // TODO Change this to actually load a settings page which will have projectile selection among other things
        SceneManager.LoadScene("SettingsScene");
    }


    public void OnClickProjectileSelectionButton()
    {
        SceneManager.LoadScene("ProjectileSelectionScreen");
    }

    public void OnClickExitButton()
    {
        Application.Quit();
    }
}
