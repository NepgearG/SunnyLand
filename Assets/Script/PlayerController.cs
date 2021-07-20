using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //速度，跳跃力
    float speed = 400;
    float jumpForce = 10;
    public LayerMask ground;
    public AudioSource jumpAudio;
    public Transform celling;

    //component
    Animator _animator;
    Rigidbody2D _rigidbody2D;
    Collider2D _collider2D;
    Collider2D closeCollider;

    //判定类全局变量
    bool secondJump = true;
    bool hasKey;
    bool onGround;
    bool battle;
    bool checkHead;

    //数字型变量
    float secondJumptimer;
    float horizontal;
    float faceDirection;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _collider2D = GetComponent<CircleCollider2D>();
        closeCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        faceDirection = Input.GetAxisRaw("Horizontal");
        horizontal = Input.GetAxis("Horizontal");
        jump();
        crouch();
    }
    void FixedUpdate()
    {
        if (!battle)
        {
            movement();
        }
        SwitchAnimator();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //跳跃优化
        onGround = false;
        if (collision.GetContact(0).normal.y > 0.5 && (collision.gameObject.CompareTag("Ground")))
        {
            onGround = true;
        }
        
    }

    void jump()
    {
        if (Input.GetButtonDown("Jump") && onGround)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x,  jumpForce);
            _animator.SetBool("IsJump", true);
            onGround = false;
            jumpAudio.Play();
        }
        else if (Input.GetButtonDown("Crouch") && onGround)
        {
            _animator.SetBool("IsCrouch", true);
        }

        if (_animator.GetBool("IsJump"))
        {
            secondJumptimer++;
        }

        if (Input.GetButtonDown("Jump") && !onGround && secondJump && secondJumptimer > 20)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
            _animator.SetBool("IsJump", true);
            secondJump = false;
            jumpAudio.Play();
        }

        if (_collider2D.IsTouchingLayers(ground))
        {
            secondJump = true;
            secondJumptimer = 0;
        }
        
    }

    void crouch()
    {
        if (Input.GetButtonDown("Crouch"))
            {
                _animator.SetBool("IsCrouch", true);
                closeCollider.enabled = false;
            }
        else if (Input.GetButtonUp("Crouch"))
        {
            checkHead = true;
        }
        if (checkHead)
        {
            if(!Physics2D.OverlapCircle(celling.position, 0.2f, ground))
            {
                closeCollider.enabled = true;
                _animator.SetBool("IsCrouch", false);
                checkHead = false;
            }
        }
        
    }
    //移动相关
    void movement()
    {
        //x轴移动
        if(horizontal != 0)
        {
            _rigidbody2D.velocity = new Vector2( horizontal * speed * Time.fixedDeltaTime, _rigidbody2D.velocity.y);
            _animator.SetBool("IsRunning", true);
        }

        if (_rigidbody2D.velocity.x == 0)
        {
            _animator.SetBool("IsRunning", false);
            }

        //更换方向
        if (faceDirection != 0)
        {
            transform.localScale = new Vector3(faceDirection, 1, 1);
        }
    }

    //切换动画
    void SwitchAnimator()
    {
        _animator.SetBool("IsIdle", false);
        if (_animator.GetBool("IsJump"))
        {
            if (_rigidbody2D.velocity.y < 0)
            {
                _animator.SetBool("IsJump", false);
                _animator.SetBool("IsFall", true);
            }
        }

        else if (_collider2D.IsTouchingLayers(ground))
        {
            _animator.SetBool("IsFall", false);
            _animator.SetBool("IsIdle", true);
        }
    }

    public void setBattle(bool status)
    {
        battle = status;
    }

    public void setKey(bool status)
    {
        this.hasKey = status;
    }

    public bool getKeyStatus()
    {
        return hasKey;
    }
}
