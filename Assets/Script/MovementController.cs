using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [Header("Movement var")]
    public float speedRate = 8f;
    public float crouchSpeed = 3f;
    public float distance = 2f;

    [Header("Jump var")]
    public float jumpForce = 6f;
    //public float jumpHoldForce = 2f;
    //public float jumpHoldDuration = 0.1f;
    public float crouchJumpBoost = 3f;
    int secondJump = 0;

    float xVelocity, vertical;

    [Header("status")]
    bool isCrouch, isOnGround, isJump, isBattle, isClimb, hasKey, isHeadBlock;
    bool jumpPressed, crouchHeld;

    [Header("Environment Check")]
    public LayerMask ground, ladder;
    float footOffset = 0.40f;
    float head = 0.5f;
    float groundCheck = 0.3f;
    float horizontal;

    [Header("AudioSource")]
    public AudioSource key, jumpAudio;

    //Åö×²Ìå³ß´ç´æ·Å
    Vector2 colliderStandSize;
    Vector2 colliderStandOffset;
    Vector2 colliderCrouchSize;
    Vector2 colliderCrouchOffset;

    Animator playerAnimator;
    Rigidbody2D rb;
    CapsuleCollider2D capsuleCollider;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        playerAnimator = GetComponent<Animator>();
        colliderStandSize = capsuleCollider.size;
        colliderStandOffset = capsuleCollider.offset;
        colliderCrouchSize = new Vector2(capsuleCollider.size.x, capsuleCollider.size.y / 2f);
        colliderCrouchOffset = new Vector2(capsuleCollider.offset.x, capsuleCollider.offset.y / 2f +0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        xVelocity = Input.GetAxis("Horizontal");
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        crouchHeld = Input.GetButton("Crouch");
        if (Input.GetButtonDown("Jump") && secondJump > 0)
        {
            jumpPressed = true;
        }
        Jump();
        climb();
    }

    void FixedUpdate()
    {
        PhysicsCheck();
        if (!isBattle)
        {
            newMovement();
        }
        
        switchAnimation();
    }

   

    //movement
    void newMovement()
    {
        
        if (crouchHeld && !isCrouch && isOnGround)
            Crouch();
        else if ((!crouchHeld && isCrouch && !isHeadBlock) || (!isOnGround && isCrouch))
            StandUp();
           

        if (isCrouch)
            horizontal /= crouchSpeed; 

        rb.velocity = new Vector2(horizontal * speedRate, rb.velocity.y);

        Direction();
    }
    
    //facedirection change
    void Direction()
    {
        if (xVelocity < 0)
            transform.localScale = new Vector2(-1, 1);
        if (xVelocity > 0)
            transform.localScale = new Vector2(1, 1);
    }
   
    //Physics Check
    void PhysicsCheck()
    {
        RaycastHit2D leftCheck = Raycast(new Vector2(-footOffset, 0f), Vector2.down, groundCheck, ground);
        RaycastHit2D rightCheck = Raycast(new Vector2(footOffset, 0f), Vector2.down, groundCheck, ground);
        
        if (leftCheck || rightCheck)
            isOnGround = true;
        else isOnGround = false;

        RaycastHit2D leftHeadCheck = Raycast(new Vector2(-footOffset, capsuleCollider.size.y), Vector2.up, head, ground);
        RaycastHit2D rightHeadCheck = Raycast(new Vector2(footOffset, capsuleCollider.size.y), Vector2.up, head, ground);
        if (leftHeadCheck|| rightHeadCheck)
            isHeadBlock = true;
        else isHeadBlock = false;
    }

    //ÌøÔ¾ÖÕ¼«ÓÅ»¯
    void Jump()
    {
        if (isOnGround)
        {
            secondJump = 1;
            isJump = false;
        }
        if (jumpPressed && isOnGround && !isJump)
        {
            if(isCrouch)
            {
                StandUp();
                isJump = true;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce+crouchJumpBoost);
                secondJump--;
                jumpPressed = false;
            }
            else
            {
                isJump = true;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                secondJump--;
                jumpPressed = false;
            }
        }
        else if (jumpPressed && secondJump > 0 && !isOnGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            secondJump--;
            jumpPressed = false;
        }
    }

    //climb
    void climb()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, ladder);
        Debug.DrawRay(transform.position, Vector2.up * distance, Color.red);
        if (hitInfo.collider != null)
        {
            if (Input.GetButtonDown("Jump"))
                isClimb = true;
        }
        else
        {
            isClimb = false;
        }
        if (isClimb == true)
        {
            rb.velocity = new Vector2(rb.position.x, vertical * speedRate);
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = 2;
        }
    }

    //crouch
    void Crouch()
    {
        isCrouch = true;
        playerAnimator.SetBool("IsCrouch", true);
        capsuleCollider.size = colliderCrouchSize;
        capsuleCollider.offset = colliderCrouchOffset;
    }
    
    //standup
    void StandUp()
    {
        isCrouch = false;
        playerAnimator.SetBool("IsCrouch", false);
        capsuleCollider.size = colliderStandSize;
        capsuleCollider.offset = colliderStandOffset;
    }

    //¶¯»­Ç¨ÒÆ
    void switchAnimation()
    {
        playerAnimator.SetFloat("IsRunning", Mathf.Abs(rb.velocity.x));
        if (isOnGround)
        {
            playerAnimator.SetBool("IsFall", false);
        }
        else if (!isOnGround && rb.velocity.y > 0)
        {
            playerAnimator.SetBool("IsJump", true);
        }
        else if (rb.velocity.y < 0)
        {
            playerAnimator.SetBool("IsJump", false);
            playerAnimator.SetBool("IsFall", true);
        }
        if (isClimb)
        {
            playerAnimator.SetBool("IsClimb", true);
        }
        else
        {
            playerAnimator.SetBool("IsClimb", false);
        }
    }

    

    //setkey
    public void setKey(bool status)
    {
        this.hasKey = status;
    }

    //getkey
    public bool getKeyStatus()
    {
        return hasKey;
    }

    //set battle status
    public void setBattle(bool status)
    {
        isBattle = status;
    }

    //Raycast override
    RaycastHit2D Raycast(Vector2 offset, Vector2 rayDirection, float length, LayerMask layer)
    {
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(pos + offset, rayDirection, length, layer);
        Color color = hit ? Color.red : Color.green;
        Debug.DrawRay(pos + offset, rayDirection * length, color);

        return hit;
    }
}
