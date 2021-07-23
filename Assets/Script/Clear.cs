using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear : MonoBehaviour
{
    [SerializeField]
    private GameObject block, tips;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            ScoreController player = collision.gameObject.GetComponent<ScoreController>();
            if (player.getCoin() == 5)
            {
                block.SetActive(false);
                Destroy(gameObject);
            }
            else
            {
                tips.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            tips.SetActive(false);
        }
    }
}
