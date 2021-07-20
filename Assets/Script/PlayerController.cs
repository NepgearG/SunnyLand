using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public LayerMask ground;
    public AudioSource jumpAudio;
    public Transform celling, groundCheck;
    public AudioSource key;
    //component
    Animator _animator;
    Rigidbody2D _rigidbody2D;
    Collider2D _collider2D;
    Collider2D closeCollider;

    //判定类全局变量
    int  secondJump = 0;
    float speed = 10;
    float jumpForce = 10;
    bool hasKey;
    bool onGround, battle, checkHead, isJump, jumpPressed;

    float horizontal;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _collider2D = GetComponent<CircleCollider2D>();
        closeCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if(Input.GetButtonDown("Jump") && secondJump > 0)
        {
            jumpPressed = true;
        }
        crouch();
    }
    void FixedUpdate()
    {

        onGround = Physics2D.OverlapCircle(groundCheck.position, 0.2f, ground);
        if (!battle)
        {
            newMovement();
        }
        jumpV2();
        switchAnimation();
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

    //动画迁移
    void switchAnimation()
    {
        _animator.SetFloat("IsRunning", Mathf.Abs(_rigidbody2D.velocity.x));
        if (onGround)
        {
            _animator.SetBool("IsFall", false);
        }
        else if (!onGround && _rigidbody2D.velocity.y >0)
        {
            _animator.SetBool("IsJump", true);
        }
        else if (_rigidbody2D.velocity.y < 0)
        {
            _animator.SetBool("IsJump", false);
            _animator.SetBool("IsFall", true);
        }
    }
    //跳跃终极优化
    void jumpV2()
    {
        if (onGround)
        {
            secondJump = 2;
            isJump = false;
        }
        if(jumpPressed && onGround)
        {
            isJump = true;
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
            secondJump--;
            jumpPressed = false;
        }
        else if (jumpPressed && secondJump >0 && !onGround) 
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
            secondJump--;
            jumpPressed = false;
        }
    }

    //移动优化
    void newMovement()
    {
        _rigidbody2D.velocity = new Vector2(horizontal * speed, _rigidbody2D.velocity.y);

        if(horizontal != 0)
        {
            transform.localScale = new Vector3(horizontal, 1, 1);
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

    /*void jump()
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
        
    }*/
    /*  //跳跃优化
  void newJump()
  {
      if (onGround)
      {
          secondJump = 1;
      }
      if(Input.GetButtonDown("Jump") && secondJump > 0)
      {
          //Vector2.up = new Vector(0, 1)
          _rigidbody2D.velocity = Vector2.up * jumpForce;
          secondJump--;
          _animator.SetBool("IsJump", true);
      }
      if(Input.GetButtonDown("Jump") && secondJump == 0 && onGround)
      {
          _rigidbody2D.velocity = Vector2.up * jumpForce;
          _animator.SetBool("IsJump", true);
      }
  }*/
    /*    //移动相关
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
    }*/
    /*  //跳跃优化
  void newJump()
  {
      if (onGround)
      {
          secondJump = 1;
      }
      if(Input.GetButtonDown("Jump") && secondJump > 0)
      {
          //Vector2.up = new Vector(0, 1)
          _rigidbody2D.velocity = Vector2.up * jumpForce;
          secondJump--;
          _animator.SetBool("IsJump", true);
      }
      if(Input.GetButtonDown("Jump") && secondJump == 0 && onGround)
      {
          _rigidbody2D.velocity = Vector2.up * jumpForce;
          _animator.SetBool("IsJump", true);
      }
  }*/
}
