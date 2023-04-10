using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{

    private void Start()
    {
        SoundManager.Instance.PlayBgMusic(SoundManager.BgMusicTypes.MainBgMusic);
    }

    public void Restart()
    {
        SoundManager.Instance.PlaySound(SoundManager.SoundTypes.ButtonClick);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
