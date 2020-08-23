using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private SoundManager sm;
    private AudioSource[] sounds;
    private AudioSource backgroundMusic;
    private AudioSource tap;
    private AudioSource pop01;
    private AudioSource pop02;
    private AudioSource bounce01;
    private AudioSource gameOverSound;
    private AudioSource iceCrack;   // final crack sound
    private AudioSource iceCrack02; // pre crack sound
    private AudioSource clapping;
    private AudioSource hitBrick;

    private float backgroundMusicMaxVolume;

    //private int _blockCount;
    private int _blueBlockCt;
    private int _redBlockCt;
    private int _iceBlockCt;
    private Scene currentScene;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject pauseUI;
    private GameObject missionCompleteCanvas;
    private GameObject missionCanvas;
    private GameObject helpCanvas;
    [SerializeField] private TMP_Text howToPlayText;
    private GameObject pelota;
    private GameObject playUI;
    [SerializeField] private GameObject ball01;
    [SerializeField] private GameObject ball02;
    [SerializeField] private GameObject ball03;
    [SerializeField] private GameObject ball04;
    [SerializeField] private GameObject football01;
    [SerializeField] private GameObject triangle01;
    [SerializeField] private GameObject triangle02;
    [SerializeField] private GameObject triangle03;
    [SerializeField] private GameObject arrow;
    [SerializeField] private GameObject rocket;
    private bool _missionComplete;
    private GameObject fireWorks;
    private Dictionary<string, int> missionItems;



    private void OnEnable()
    {
        //_blockCount = 0;
        _blueBlockCt = 0;
        _redBlockCt = 0;
        _iceBlockCt = 0;
}


    // Start is called before the first frame update
    void Start()
    {
        sm = GameObject.FindGameObjectWithTag("sound_manager_tag")?.GetComponent<SoundManager>();
        sounds = GetComponents<AudioSource>();
        backgroundMusic = sounds[0];
        pop01 = sounds[1];
        pop02 = sounds[2];
        bounce01 = sounds[3];
        tap = sounds[4];
        gameOverSound = sounds[5];
        iceCrack = sounds.Length >= 7 ? sounds[6] : null;
        iceCrack02 = sounds.Length >= 8 ? sounds[7] : null;
        clapping = sounds.Length >= 9 ? sounds[8] : null;
        hitBrick = sounds.Length >= 10 ? sounds[9] : null;
        currentScene = SceneManager.GetActiveScene();
        missionItems = Mission.GetMissionItems(currentScene);
        _missionComplete = false;

        backgroundMusicMaxVolume = backgroundMusic.volume;


        playUI = GameObject.FindGameObjectWithTag("play_ui_tag");
        missionCompleteCanvas = GameObject.FindGameObjectWithTag("mission_complete_ui_tag")?.transform.GetChild(0).gameObject;
        missionCompleteCanvas.SetActive(false);
        missionCanvas = GameObject.FindGameObjectWithTag("mission_ui_tag")?.transform.GetChild(0).gameObject;
        helpCanvas = GameObject.FindGameObjectWithTag("mission_ui_tag")?.transform.GetChild(1).gameObject;
        helpCanvas.SetActive(false);
        howToPlayText.text = Settings.IsPlayWithMotion() ? "Tilt Your Device Left And Right To Move The Paddle\nDon't Let The Projectile Fall To The Ground" :
            "Touch The Left Or Right Side Of The Screen To Move The Paddle\nDon't Let The Projectile Fall To The Ground";
        fireWorks = GameObject.FindGameObjectWithTag("fireworks_tag");
        fireWorks?.transform.GetChild(0).gameObject.SetActive(false);
        fireWorks?.transform.GetChild(1).gameObject.SetActive(false);

        string chosenProjectile = PlayerPrefs.GetString("ChosenProjectile", "none");

        switch (chosenProjectile)
        {
            case "Ball01":
                pelota = GameObject.Instantiate(ball01, new Vector3(0f, -4.13f, -.4f), Quaternion.identity);
                break;
            case "Ball02":
                pelota = GameObject.Instantiate(ball02, new Vector3(0f, -4.13f, -.4f), Quaternion.identity);
                break;
            case "Ball03":
                pelota = GameObject.Instantiate(ball03, new Vector3(0f, -4.13f, -.4f), Quaternion.identity);
                break;
            case "Ball04":
                pelota = GameObject.Instantiate(ball04, new Vector3(0f, -4.13f, -.4f), Quaternion.identity);
                break;
            case "Football01":
                pelota = GameObject.Instantiate(football01, new Vector3(0f, -4.13f, -.4f), Quaternion.identity);
                break;
            case "Triangle01":
                pelota = GameObject.Instantiate(triangle01, new Vector3(0f, -4.13f, -.4f), Quaternion.identity);
                break;
            case "Triangle02":
                pelota = GameObject.Instantiate(triangle02, new Vector3(0f, -4.13f, -.4f), Quaternion.identity);
                break;
            case "Triangle03":
                pelota = GameObject.Instantiate(triangle03, new Vector3(0f, -4.13f, -.4f), Quaternion.identity);
                break;
            case "Arrow":
                pelota = GameObject.Instantiate(arrow, new Vector3(0f, -4.13f, -.4f), Quaternion.identity);
                break;
            case "Rocket":
                pelota = GameObject.Instantiate(rocket, new Vector3(0f, -4.13f, -.4f), Quaternion.identity);
                break;
            default:
                pelota = GameObject.Instantiate(ball03, new Vector3(0f, -4.13f, -.4f), Quaternion.identity);
                break;
        }

        ShowMission();

    }





    // Update is called once per frame
    void Update()
    {
        // check if mission is complete
        if (!_missionComplete && IsMissionCompleteNow()) { ClearedLevel(); };
    }

    private bool IsMissionCompleteNow()
    {
        foreach(KeyValuePair<string, int> pair in missionItems)
        {
            if (pair.Key.Equals("BlueBlock") && (_blueBlockCt > pair.Value))
                return false;
            if (pair.Key.Equals("RedBlock") && (_redBlockCt > pair.Value))
                return false;
            if (pair.Key.Equals("IceBlock") && (_iceBlockCt > pair.Value))
                return false;
        }
        return true;
    }

    // Sounds
    public void PlayBackgroundMusic()
    {
        backgroundMusic.volume = (Settings.GetMusicVolume() / 100f) * backgroundMusicMaxVolume;
        backgroundMusic.Play();
    }
    public void PlayTapSound()
    {
        sm.PlayTapSound();
    }
    public void PlayPop01Sound()
    {
        sm.PlayPop01Sound();
    }
    public void PlayPop02Sound()
    {
        sm.PlayPop02Sound();
    }
    public void PlayBounce01Sound()
    {
        sm.PlayBounce01Sound();
    }
    public void PlayIceCrackSound()
    {
        sm.PlayIceCrackSound();
    }
    public void PlayIceCrack02Sound()
    {
        sm.PlayIceCrack02Sound();
    }
    public void PlayClappingSound()
    {
        sm.PlayClappingSound();
    }
    public void PlayHitBrickSound()
    {
        sm.PlayHitBrickSound();
    }




    // Helpers
    public void DecrementBlueBlockCount() => _blueBlockCt--;
    public void IncrementBlueBlockCount() => _blueBlockCt++;
    public void IncrementRedBlockCount() => _redBlockCt++;
    public void DecrementRedBlockCount() => _redBlockCt--;
    public void DecrementIceBlockCount() => _iceBlockCt--;
    public void IncrementIceBlockCount() => _iceBlockCt++;

    public void ShowMission()
    {
        Time.timeScale = 0;
        playUI.SetActive(false);
        missionCanvas.SetActive(true);
    }
    private void ClearedLevel()
    {
        PongoCoinManager.Deposit(PongoCoinManager.PongoCoinsForScene(currentScene.name));
        
        backgroundMusic.Stop();
        _missionComplete = true;
        int currentMaxLevel = PlayerPrefs.GetInt("MaxLevelReached", -1);

        switch (currentScene.name)
        {
            case "Level01": if (currentMaxLevel < 2) { PlayerPrefs.SetInt("MaxLevelReached", 2); }; break;
            case "Level02": if (currentMaxLevel < 3) { PlayerPrefs.SetInt("MaxLevelReached", 3); }; break;
            case "Level03": if (currentMaxLevel < 4) { PlayerPrefs.SetInt("MaxLevelReached", 4); }; break;
            case "Level04": if (currentMaxLevel < 5) { PlayerPrefs.SetInt("MaxLevelReached", 5); }; break;
            case "Level05": if (currentMaxLevel < 6) { PlayerPrefs.SetInt("MaxLevelReached", 6); }; break;
            case "Level06": if (currentMaxLevel < 7) { PlayerPrefs.SetInt("MaxLevelReached", 7); }; break;
            case "Level07": if (currentMaxLevel < 8) { PlayerPrefs.SetInt("MaxLevelReached", 8); }; break;
            case "Level08": if (currentMaxLevel < 9) { PlayerPrefs.SetInt("MaxLevelReached", 9); }; break;
        }
        pelota.GetComponent<Pelota>()?.Die();
        missionCompleteCanvas.SetActive(true);
        // Enable Firework particle Spawners here
        fireWorks?.transform.GetChild(0).gameObject.SetActive(true);
        fireWorks?.transform.GetChild(1).gameObject.SetActive(true);
        // Play Clap sound here
        sm.PlayClappingSound();
    }
    public void GameOver()
    {
        playUI.SetActive(false);
        backgroundMusic.Stop();
        gameOverSound.Play();
        pelota.SetActive(false);
        gameOverUI.SetActive(true);
    }



    // Buttons
    public void OnClickRestartButton()
    {
        sm.StopClappingSound();
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OnClickHomeButton()
    {
        sm.StopClappingSound();
        Time.timeScale = 1;
        SceneManager.LoadScene("InitialScreen");
    }
    public void OnClickQuitButton()
    {
        Application.Quit();
    }
    public void OnClickResumeButton()
    {
        Time.timeScale = 1;
        backgroundMusic.UnPause();
        pauseUI.SetActive(false);
    }
    public void OnClickPauseButton()
    {
        Time.timeScale = 0;
        pauseUI.SetActive(true);
        backgroundMusic.Pause();
    }
    public void OnClickNextLevelButton()
    {
        sm.StopClappingSound();
        string currScene = currentScene.name;
        switch (currScene)
        {
            case "Level01": SceneManager.LoadScene("Level02"); break;
            case "Level02": SceneManager.LoadScene("Level03"); break;
            case "Level03": SceneManager.LoadScene("Level04"); break;
            case "Level04": SceneManager.LoadScene("Level05"); break;
            case "Level05": SceneManager.LoadScene("Level06"); break;
            case "Level06": SceneManager.LoadScene("Level07"); break;
            case "Level07": SceneManager.LoadScene("Level08"); break;
            //case "Level08": SceneManager.LoadScene("Level09"); break;
            default: SceneManager.LoadScene("InitialScreen"); break;
        }
    }
    public void OnClickMissionOKButton()
    {
        Time.timeScale = 1;
        playUI.SetActive(true);
        missionCanvas.SetActive(false);
        PlayBackgroundMusic();
    }

    public void OnClickHelpButton()
    {
        helpCanvas.SetActive(true);
        missionCanvas.SetActive(false);
    }

    public void OnClickHelpOKButton()
    {
        helpCanvas.SetActive(false);
        missionCanvas.SetActive(true);
    }
}
