using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{
    private AudioSource mainMenuSong;
    private float _mainMenuSongMaxVolume;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        if(GameObject.FindGameObjectsWithTag("main_menu_music_tag").Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(transform.gameObject);
            mainMenuSong = GetComponent<AudioSource>();
            _mainMenuSongMaxVolume = mainMenuSong.volume;
            PlayMainMenuMusic();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public float GetMainMenuSongMaxVolume()
    {
        return _mainMenuSongMaxVolume;
    }

    public void StopMainMenuMusic()
    {
        mainMenuSong.Stop();
    }
    public void PlayMainMenuMusic()
    {
        if (!mainMenuSong.isPlaying)
        {
            mainMenuSong.volume = (Settings.GetMusicVolume() / 100) * _mainMenuSongMaxVolume;
            mainMenuSong.Play();
        }
    }

    public void SetVolume(float v)
    {
        mainMenuSong.volume = v;
    }



    // from scenes use this code:
    // GameObject.FindGameObjectWithTag("MainMenuMusic").GetComponent<MusicClass>().PlayMainMenuMusic();
}
