using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject UI;
    //startgame
    public void StartGame()
    {
        SceneManager.LoadScene("FirstScene");
    }

    //quitgame
    public void QuitGame()
    {
        Application.Quit();
    }

    //fronteffect

    public void UIEnable()
    {
        UI.SetActive(true);
    }
}
