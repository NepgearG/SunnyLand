using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorController : GameManager
{

    public GameObject enterDialog;
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController pController = collision.gameObject.GetComponent<PlayerController>();

        if(pController!=null && pController.getKeyStatus())
        {
            enterDialog.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("BossScene");
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            enterDialog.SetActive(false);
        }
    }


}
