using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Text score;
    public Text cherryNumber;
    public Text diamondNumber;
    public Text coinNum;

    int point = 0;
    int cherrys = 0;
    int diamonds = 0;
    int coins = 0;

    private void Start()
    {
        if(System.IO.File.Exists(Application.persistentDataPath + "/" + SaveManagement.instance.datas.saveName + ".save"))
        {
            SaveManagement.instance.Load();
            point = SaveManagement.instance.datas.score;
            cherrys = SaveManagement.instance.datas.cherryNums;
            diamonds = SaveManagement.instance.datas.diamondNums;
        }
        else
        {
            SaveManagement.instance.datas.score = point;
            SaveManagement.instance.datas.cherryNums = cherrys;
            SaveManagement.instance.datas.diamondNums = diamonds;
        }
    }

    private void Update()
    {
        score.text = getPoint().ToString();
        cherryNumber.text = getCherryNum().ToString();
        diamondNumber.text = getDiamondNum().ToString();
        coinNum.text = getCoin().ToString();
    }
    public void AddPoint(string pointType)
    {
        if (pointType == "Cherry")
        {
            this.point += 10;
        }
        else if (pointType == "Diamond")
        {
            this.point += 100;
        }
        else if (pointType == "Coin")
        {
            this.point += 10;
        }
        SaveManagement.instance.datas.score = point;
        SaveManagement.instance.Save();
    }

    public void AddItemNum(string ItemType)
    {
        if (ItemType == "Cherry")
        {
            cherrys +=1;
            SaveManagement.instance.datas.cherryNums = cherrys;
        }
        else if (ItemType == "Diamond")
        {
            diamonds += 1;
            SaveManagement.instance.datas.diamondNums = diamonds;
        }
        else if (ItemType == "Coin")
        {
            coins += 1;
        }
    }

    //get
    public int getCherryNum()
    {
        return cherrys;
    }

    public int getDiamondNum()
    {
        return diamonds;
    }

    public int getPoint()
    {
        return point;
    }

    public int getCoin()
    {
        return coins;
    }
}
