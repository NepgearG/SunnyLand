using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform Cam;
    public float moveRate;

    float startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(startPosition + Cam.position.x* moveRate, transform.position.y);
    }
}
