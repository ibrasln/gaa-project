using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance;
    
    public enum SoundTypes {Attack , Damage, NewWave, ButtonClick, Lose, Monster};
    public enum BgMusicTypes {MainBgMusic};
    
    public AudioSource attackSound;
    public AudioSource damageSound;
    public AudioSource newWaveSound;
    public AudioSource loseSound;
    public AudioSource monsterSound;
    public AudioSource buttonClickSound;
    
    public AudioSource bgMusic;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    
    public void PlayBgMusic(BgMusicTypes currentMusic)
    {
        switch (currentMusic)
        {
            case BgMusicTypes.MainBgMusic:
                bgMusic.Play();
                bgMusic.volume = 0.1f;
                break;
        }
    }

    public void PlaySound(SoundTypes currentSound)
    {
        switch (currentSound)
        {
            case SoundTypes.Attack:
                attackSound.Play();
                break;
            case SoundTypes.Damage:
                damageSound.Play();
                break;
            case SoundTypes.NewWave:
                newWaveSound.Play();
                break;
            case SoundTypes.ButtonClick:
                buttonClickSound.Play();
                break;
            case SoundTypes.Lose:
                loseSound.Play();
                break;
            case SoundTypes.Monster:
                monsterSound.Play();
                break;
        }
    }
}
