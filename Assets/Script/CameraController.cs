using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        //����player
        transform.position = new Vector3(player.position.x, player.position.y, -10f);
    }
}
