using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorController : GameManager
{

    public GameObject next;
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        MovementController player = collision.gameObject.GetComponent<MovementController>();

        if (player != null && player.getKeyStatus())
        {
            next.SetActive(true);
        }
        SaveManagement.instance.Save();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            next.SetActive(false);
        }
    }


}
