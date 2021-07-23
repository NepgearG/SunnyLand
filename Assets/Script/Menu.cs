using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject UI;
    [SerializeField]
    private Text text;

    private void Start()
    {
        if (System.IO.File.Exists(Application.persistentDataPath + "/" + SaveManagement.instance.datas.saveName + ".save"))
        {
            SaveManagement.instance.Load();
            text.text = SaveManagement.instance.datas.score.ToString() ;
        }
    }
    //startgame
    public void StartGame()
    {
        if (System.IO.File.Exists(Application.persistentDataPath + "/" + SaveManagement.instance.datas.saveName + ".save"))
        {
            SaveManagement.instance.DeleteSaveData();
        }
            SceneManager.LoadScene("FirstScene");
    }

    //quitgame
    public void QuitGame()
    {
        if (System.IO.File.Exists(Application.persistentDataPath + "/" + SaveManagement.instance.datas.saveName + ".save"))
        {
            SaveManagement.instance.DeleteSaveData();
        }
        Application.Quit();
    }

    //fronteffect

    public void UIEnable()
    {
        UI.SetActive(true);
    }
}
