using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
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

    private float tapMaxVolume;
    private float pop01MaxVolume;
    private float pop02MaxVolume;
    private float bounce01MaxVolume;
    private float gameOverSoundMaxVolume;
    private float iceCrackMaxVolume;
    private float iceCrack02MaxVolume;
    private float clappingMaxVolume;
    private float hitBrickMaxVolume;

    private void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("sound_manager_tag").Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(transform.gameObject);
        }
    }

    void Start()
    {
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

        tapMaxVolume = tap.volume;
        pop01MaxVolume = pop01.volume;
        pop02MaxVolume = pop02.volume;
        bounce01MaxVolume = bounce01.volume;
        gameOverSoundMaxVolume = gameOverSound.volume;
        iceCrackMaxVolume = iceCrack.volume;
        iceCrack02MaxVolume = iceCrack02.volume;
        clappingMaxVolume = clapping.volume;
        hitBrickMaxVolume = hitBrick.volume;
    }

    void Update()
    {
        
    }

    public void PlayTapSound()
    {
        tap.volume = (Settings.GetEffectsVolume() / 100f) * tapMaxVolume;
        tap.Play();
    }
    public void PlayPop01Sound()
    {
        pop01.volume = (Settings.GetEffectsVolume() / 100f) * pop01MaxVolume;
        pop01.Play();
    }
    public void PlayPop02Sound()
    {
        pop02.volume = (Settings.GetEffectsVolume() / 100f) * pop02MaxVolume;
        pop02.Play();
    }
    public void PlayBounce01Sound()
    {
        pop01.volume = (Settings.GetEffectsVolume() / 100f) * pop01MaxVolume;
        bounce01.Play();
    }
    public void PlayIceCrackSound()
    {
        iceCrack.volume = (Settings.GetEffectsVolume() / 100f) * iceCrackMaxVolume;
        iceCrack.Play();
    }
    public void PlayIceCrack02Sound()
    {
        iceCrack02.volume = (Settings.GetEffectsVolume() / 100f) * iceCrack02MaxVolume;
        iceCrack02.Play();
    }
    public void PlayClappingSound()
    {
        clapping.volume = (Settings.GetEffectsVolume() / 100f) * clappingMaxVolume;
        clapping.Play();
    }
    public void StopClappingSound()
    {
        clapping.Stop();
    }
    public void PlayHitBrickSound()
    {
        hitBrick.volume = (Settings.GetEffectsVolume() / 100f) * hitBrickMaxVolume;
        hitBrick.Play();
    }


}
