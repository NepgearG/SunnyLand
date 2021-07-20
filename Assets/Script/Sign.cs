using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    public GameObject enterDialog;
     void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController pController = collision.gameObject.GetComponent<PlayerController>();

        if (pController != null)
        {
            enterDialog.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            enterDialog.SetActive(false);
        }
    }
}
