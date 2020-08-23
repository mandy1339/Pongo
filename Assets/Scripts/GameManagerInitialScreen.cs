using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerInitialScreen : MonoBehaviour
{
    //private AudioSource mainMenuBackgroundMusic;
    private MainMenuMusic mainMenuMusic;
    // Start is called before the first frame update
    void Start()
    {
        mainMenuMusic = GameObject.FindGameObjectWithTag("main_menu_music_tag").GetComponent<MainMenuMusic>();
        mainMenuMusic.PlayMainMenuMusic();

        // TODO remove these 
        //PlayerPrefs.SetInt("PlayWithMotion", -1);
        //PlayerPrefs.SetString("Inventory", "");
        //PlayerPrefs.SetInt("ShowMotionMessage", 1);
        //PlayerPrefs.SetString("ChosenProjectile", "");


        // Start with motion controls by default until changed by user in settings
        if (PlayerPrefs.GetInt("PlayWithMotion",-1) == -1)
        {
            Settings.EnableMotionControls();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickPlayButton()
    {
        if (PlayerPrefs.GetInt("ShowMotionMessage", 1) == 1)
        {
            SceneManager.LoadScene("MotionControlMessageScene");
        }
        else
        {
            SceneManager.LoadScene("LevelSelectionScreen");
        }
    }

    public void OnClickQuitButton()
    {
        Application.Quit();
    }
}
