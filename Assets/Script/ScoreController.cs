using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Text score;
    public Text cherryNumber;
    public Text diamondNumber;
    public AudioSource cherryAudio, diamondAudio;

    int point = 0;
    int cherrys = 0;
    int diamonds = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }

    public void AddItemNum(string ItemType)
    {
        if (ItemType == "Cherry")
        {
            cherrys +=1;
        }
        else if (ItemType == "Diamond")
        {
            diamonds += 1;
        }
    }

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
}
