using UnityEngine;
using System.Collections;

public static class Settings
{
    private static bool _isInitialized = false;
    private static int _playWithMotion = 1;   // 1 yes 0 no;
    private static float _musicVolume;
    private static float _effectsVolume;


    public static bool IsPlayWithMotion() 
    {
        if (!_isInitialized)
            Init();
        return _playWithMotion == 1 ? true : false;
    }


    public static void Init()
    {
        _isInitialized = true;
        _playWithMotion = PlayerPrefs.GetInt("PlayWithMotion", 1);      // fetch the setting from device memory
        _musicVolume = PlayerPrefs.GetFloat("MusicVolume", 100);
        _effectsVolume = PlayerPrefs.GetFloat("EffectsVolume", 100);
    }


    public static void DisableMotionControls()
    {
        if (!_isInitialized)
            Init();
        PlayerPrefs.SetInt("PlayWithMotion", 0);
        _playWithMotion = 0;
    }

    public static void EnableMotionControls()
    {
        if (!_isInitialized)
            Init();
        PlayerPrefs.SetInt("PlayWithMotion", 1);
        _playWithMotion = 1;
    }

    public static float GetMusicVolume()
    {
        if (!_isInitialized)
            Init();
        return _musicVolume;
    }

    public static float GetEffectsVolume()
    {
        if (!_isInitialized)
            Init();
        return _effectsVolume;
    }

    public static float IncreaseMusicVolume()
    {
        if (!_isInitialized)
            Init();
        if (_musicVolume <= 75)
        {
            _musicVolume += 25;
            PlayerPrefs.SetFloat("MusicVolume", _musicVolume);
        }
        return _musicVolume;
    }

    public static float DecreaseMusicVolume()
    {
        if (!_isInitialized)
            Init();
        if (_musicVolume >=25)
        {
            _musicVolume -= 25;
            PlayerPrefs.SetFloat("MusicVolume", _musicVolume);
        }
        return _musicVolume;
    }

    public static float IncreaseEffectsVolume()
    {
        if (!_isInitialized)
            Init();
        if (_effectsVolume <= 75)
        {
            _effectsVolume += 25;
            PlayerPrefs.SetFloat("EffectsVolume", _effectsVolume);
        }
        return _effectsVolume;
    }

    public static float DecreaseEffectsVolume()
    {
        if (!_isInitialized)
            Init();
        if (_effectsVolume >= 25)
        {
            _effectsVolume -= 25;
            PlayerPrefs.SetFloat("EffectsVolume", _effectsVolume);
        }
        return _effectsVolume;
    }
}
