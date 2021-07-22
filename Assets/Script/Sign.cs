using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    public GameObject enterDialog;
     void OnTriggerEnter2D(Collider2D collision)
    {
        MovementController player = collision.gameObject.GetComponent<MovementController>();

        if (player != null)
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
