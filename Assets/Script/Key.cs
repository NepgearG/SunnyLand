using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController pController = collision.GetComponent<PlayerController>();
        if(pController != null)
        {
            pController.key.Play();
            pController.setKey(true);
            Destroy(gameObject);
        }
    }
}
