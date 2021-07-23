using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreController controller = collision.GetComponent<ScoreController>();
        if (controller != null)
        {
            SoundController.instance.SetAudioSource("cherry");
            controller.AddItemNum("Cherry");
            controller.AddPoint("Cherry");
            Destroy(gameObject);
        }
    }
}
