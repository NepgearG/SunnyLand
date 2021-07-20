using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorController : GameManager
{

    public GameObject next;
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController pController = collision.gameObject.GetComponent<PlayerController>();

        if(pController!=null && pController.getKeyStatus())
        {
            next.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            next.SetActive(false);
        }
    }


}
