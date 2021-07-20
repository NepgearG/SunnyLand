using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreController controller = collision.GetComponent<ScoreController>();
        if (controller != null)
        {
            controller.diamondAudio.Play();
            controller.AddPoint("Diamond");
            controller.AddItemNum("Diamond");
            controller.score.text = controller.getPoint().ToString();
            controller.diamondNumber.text = controller.getDiamondNum().ToString();
            Destroy(gameObject);
        }
    }
}
