using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    protected float speed;
    protected float leftx, rightx, upy, downy;

    protected Animator enemyAnimator;
    protected Rigidbody2D _rigidbody2D;
    
    protected float shift = 2;
    protected float jumpforce = 4;
    protected float jump = 2;
    protected bool faceLeft = true;
    protected bool up = true;
    protected bool onGround;
    protected AudioSource audioSource;

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController pController = collision.gameObject.GetComponent<PlayerController>();
        HpController player = collision.gameObject.GetComponent<HpController>();
        Rigidbody2D playerRigidbody2D = collision.gameObject.GetComponent<Rigidbody2D>();
        Animator pAnimator = collision.gameObject.GetComponent<Animator>();

        if (player != null)
        {
            if (collision.GetContact(0).normal.y < -0.1f)
            {
                setDeathFlag();
                playerRigidbody2D.velocity = new Vector2(playerRigidbody2D.velocity.x, -playerRigidbody2D.velocity.y * jump);
                pAnimator.SetBool("IsJump", true);
                pController.setBattle(true);
                pController.setBattle(false);
            }
            else
            {
                playerRigidbody2D.velocity = new Vector2(-playerRigidbody2D.velocity.x * shift, playerRigidbody2D.velocity.y);
                player.ChangeHealth(-1);
                pController.setBattle(true);

            }

        }
    }
    protected virtual void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    public void death()
    {
        Destroy(gameObject);
    }
    public void setDeathFlag()
    {
        audioSource.Play();
        enemyAnimator.SetTrigger("dead");
    }

}
