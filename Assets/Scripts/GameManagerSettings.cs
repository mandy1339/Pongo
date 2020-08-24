using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerSettings : MonoBehaviour
{
    [SerializeField] private Image checkImage;
    [SerializeField] private Image xImage;
    [SerializeField] private TMP_Text musicVolumeText;
    [SerializeField] private TMP_Text effectsVolumeText;
    [SerializeField] private GameObject attributionsObject;
    [SerializeField] private GameObject settingsCanvas;
    private MainMenuMusic mainMenuMusic;

    private float mainMenuMusicMaxVolume;
    private SoundManager sm;
    

    // Start is called before the first frame update
    void Start()
    {
        if (Settings.IsPlayWithMotion())
        {
            checkImage.gameObject.SetActive(true);
            xImage.gameObject.SetActive(false);
        }
        else
        {
            checkImage.gameObject.SetActive(false);
            xImage.gameObject.SetActive(true);
        }
        musicVolumeText.text = Settings.GetMusicVolume().ToString();
        effectsVolumeText.text = Settings.GetEffectsVolume().ToString();
        mainMenuMusic = GameObject.FindGameObjectWithTag("main_menu_music_tag")?.GetComponent<MainMenuMusic>();
        mainMenuMusicMaxVolume = (mainMenuMusic != null) ? mainMenuMusic.GetMainMenuSongMaxVolume() : 0;
        sm = GameObject.FindGameObjectWithTag("sound_manager_tag")?.GetComponent<SoundManager>();
    }


    public void OnClickMotionSettingButton()
    {
        if(Settings.IsPlayWithMotion())
        {
            Settings.DisableMotionControls();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            Settings.EnableMotionControls();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void OnClickBackButton()
    {
        SceneManager.LoadScene("LevelSelectionScreen");
    }

    public void OnClickQuitButton()
    {
        Application.Quit();
    }




    public void OnClickMusicVolumeDownButton()
    {
        musicVolumeText.text = Settings.DecreaseMusicVolume().ToString();
        if (mainMenuMusic != null)
        {
            mainMenuMusic.SetVolume(mainMenuMusicMaxVolume * (Settings.GetMusicVolume() / 100));
        }
    }

    public void OnClickMusicVolumeUpButton()
    {
        musicVolumeText.text = Settings.IncreaseMusicVolume().ToString();
        if (mainMenuMusic != null)
        {
            mainMenuMusic.SetVolume(mainMenuMusicMaxVolume * (Settings.GetMusicVolume() / 100));
        }
    }

    public void OnClickEffectsVolumeDownButton()
    {
        effectsVolumeText.text = Settings.DecreaseEffectsVolume().ToString();
        sm.PlayTapSound();
    }

    public void OnClickEffectsVolumeUpButton()
    {
        effectsVolumeText.text = Settings.IncreaseEffectsVolume().ToString();
        sm.PlayTapSound();
    }

    public void OnClickAttributionsButton()
    {
        attributionsObject.SetActive(true);
        settingsCanvas.SetActive(false);
    }

    public void OnClickAttributionsBackButton()
    {
        attributionsObject.SetActive(false);
        settingsCanvas.SetActive(true);
    }
}
