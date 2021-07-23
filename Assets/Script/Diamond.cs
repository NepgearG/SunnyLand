using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            ScoreController controller = collision.GetComponent<ScoreController>();
            SoundController.instance.SetAudioSource("diamond");
            controller.AddItemNum("Diamond");
            controller.AddPoint("Diamond");
            Destroy(gameObject);
        }
    }
}
