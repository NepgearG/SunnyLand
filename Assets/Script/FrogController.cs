using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : EnemyController
{
    public Transform leftpoint, rightpoint;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        speed = 4;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        leftx = leftpoint.position.x;
        rightx = rightpoint.position.x; 
        Destroy(leftpoint.gameObject);
        Destroy(rightpoint.gameObject);
    }

    private void FixedUpdate()
    {
        switchAnimation();
    }

    //敌人与玩家碰撞相关判定
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        
        base.OnCollisionEnter2D(collision);
        onGround = false;
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }

    //自动移动
    void Movement()
    {
        if (faceLeft && onGround)
        {
            enemyAnimator.SetBool("IsJump", true);
            onGround = false;
            _rigidbody2D.velocity = new Vector2(-speed, jumpforce);
            if(transform.position.x < leftx)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                _rigidbody2D.velocity = new Vector2(speed, jumpforce);
                faceLeft = false;
            }
        }
        else if (!faceLeft && onGround)
        {
            enemyAnimator.SetBool("IsJump", true);
            onGround = false;
            _rigidbody2D.velocity = new Vector2(speed, jumpforce);
            if (transform.position.x > rightx)
            {
                transform.localScale = new Vector3(1, 1, 1);
                _rigidbody2D.velocity = new Vector2(-speed, jumpforce);
                faceLeft = true;
            }
        }
    }
    
    //动画切换
    void switchAnimation()
    {
        if (enemyAnimator.GetBool("IsJump"))
        {
            if (_rigidbody2D.velocity.y < 0.1)
            {
                enemyAnimator.SetBool("IsFall", true);
                enemyAnimator.SetBool("IsJump", false);
            }
        }
        if (onGround && enemyAnimator.GetBool("IsFall"))
        {
            enemyAnimator.SetBool("IsFall", false);
        }
    }

}
