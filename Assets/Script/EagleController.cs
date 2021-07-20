using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleController : EnemyController
{
    public Transform leftpoint, rightpoint, uppoint, downpoint;
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        speed = 2;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        leftx = leftpoint.position.x;
        rightx = rightpoint.position.x;
        upy = uppoint.position.y;
        downy = downpoint.position.y;
        Destroy(leftpoint.gameObject);
        Destroy(rightpoint.gameObject);
        Destroy(uppoint.gameObject);
        Destroy(downpoint.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (faceLeft && up)
        {
            _rigidbody2D.velocity = new Vector2(-speed, jumpforce);
            if (transform.position.x < leftx)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                faceLeft = false;
            }
            else if (transform.position.y > upy)
            {
                up = false;
            }
        }
        else if (!faceLeft && up)
        {
            _rigidbody2D.velocity = new Vector2(speed, jumpforce);
            if (transform.position.x > rightx)
            {
                transform.localScale = new Vector3(1, 1, 1);
                faceLeft = true;
            }
            else if (transform.position.y > upy)
            {
                up = false;
            }
        }
        else if (faceLeft && !up)
        {
            _rigidbody2D.velocity = new Vector2(-speed, -jumpforce);
            if (transform.position.x < leftx)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                faceLeft = false;
            }
            else if (transform.position.y < downy)
            {
                up = true;
            }
        }
        else if (!faceLeft && !up)
        {
            _rigidbody2D.velocity = new Vector2(speed, -jumpforce);
            if (transform.position.x > rightx)
            {
                transform.localScale = new Vector3(1, 1, 1);
                faceLeft = true;
            }
            else if (transform.position.y < downy)
            {
                up = true;
            }
        }
    }

}
