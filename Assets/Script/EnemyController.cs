using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    protected float speed;
    protected float leftx, rightx, upy, downy;

    protected Animator enemyAnimator;
    protected Rigidbody2D _rigidbody2D;
    protected CircleCollider2D _circleCollider2D;
    
    protected float shift = 2;
    protected float jumpforce = 4;
    protected float jump = 2;
    protected bool faceLeft = true;
    protected bool up = true;
    protected bool onGround;
    protected AudioSource audioSource;

   
    protected virtual void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        _circleCollider2D = GetComponent<CircleCollider2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {

    }
    public void death()
    {
        Destroy(gameObject);
    }
    public void setDeathFlag()
    {

        _circleCollider2D.enabled = false;
        _rigidbody2D.simulated = false;
        audioSource.Play();
        enemyAnimator.SetTrigger("dead");

    }

}
