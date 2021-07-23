using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        MovementController player = collision.GetComponent<MovementController>();
        if(player != null)
        {
            SoundController.instance.SetAudioSource("key");
            player.setKey(true);
            Destroy(gameObject);
        }
    }
}
