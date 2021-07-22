using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainSceneMenuController : MonoBehaviour
{
    public GameObject UI;
    public AudioMixer audioMixer;
    public void UIEnable()
    {
        UI.SetActive(true);
        PauseGame();
    }

    public void UIDisable()
    {
        UI.SetActive(false);
        ResumeGame();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
        ResumeGame();
    }

    public void SetVolume(float value)
    {
        audioMixer.SetFloat("MainVolume",  value);
    }
    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
    }

    
}
