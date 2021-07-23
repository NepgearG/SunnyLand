using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            ScoreController player = collision.gameObject.GetComponent<ScoreController>();
            SoundController.instance.SetAudioSource("coin");
            player.AddItemNum("Coin");
            player.AddPoint("Coin");
            Destroy(gameObject);
        }
    }
}
