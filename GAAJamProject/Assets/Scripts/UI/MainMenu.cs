using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnPlayButtonClick()
    {
        SoundManager.Instance.PlaySound(SoundManager.SoundTypes.ButtonClick);
        SceneManager.LoadScene("MainGameScene");
    }
    
    public void OnQuitButtonClick()
    {
#if !UNITY_EDITOR
        Application.Quit();
#else
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
