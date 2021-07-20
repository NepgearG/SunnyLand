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
            controller.cherryAudio.Play();
            controller.AddPoint("Cherry");
            controller.AddItemNum("Cherry");
            controller.score.text = controller.getPoint().ToString();
            controller.cherryNumber.text = controller.getCherryNum().ToString();
            Destroy(gameObject);
        }
    }
}
