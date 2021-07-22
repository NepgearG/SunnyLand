using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpossumController : EnemyController
{
    public Transform leftpoint, rightpoint;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        speed = 3;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        leftx = leftpoint.position.x;
        rightx = rightpoint.position.x;
        Destroy(leftpoint.gameObject);
        Destroy(rightpoint.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        if (faceLeft)
        {
            _rigidbody2D.velocity = new Vector2(-speed, _rigidbody2D.velocity.y);
            if (transform.position.x < leftx)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                faceLeft = false;
            }
        }
        else
        {
            _rigidbody2D.velocity = new Vector2(speed, _rigidbody2D.velocity.y);
            if (transform.position.x > rightx)
            {
                transform.localScale = new Vector3(1, 1, 1);
                faceLeft = true;
            }
        }
    }
    
}
