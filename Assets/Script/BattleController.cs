using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    [Header("vars")]
    public float shift = 2;
    public float jumpForce = 0.8f;
    public float offset = 5f;


    Rigidbody2D rb;
    Animator playerAnimator;
    HpController hpController;
    MovementController movement;

    // Start is called before the first frame update
    void Start()
    {
        hpController = GetComponent<HpController>();
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        movement = GetComponent<MovementController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            
            EnemyController enemyController = collision.gameObject.GetComponent<EnemyController>();
            if (collision.contacts[0].normal.y >0.5f)
            {
                playerAnimator.SetBool("IsJump", true);
                rb.velocity = new Vector2(rb.velocity.x, 10);
                enemyController.setDeathFlag();
            }
            else if (transform.position.x < collision.gameObject.transform.position.x)
            {
                movement.setBattle(true);
                hpController.ChangeHealth(-1);
                rb.velocity = new Vector2(-5, rb.velocity.y + offset);
            }
            else if (transform.position.x > collision.gameObject.transform.position.x)
            {
                movement.setBattle(true);
                hpController.ChangeHealth(-1);
                rb.velocity = new Vector2(5, rb.velocity.y+offset);
            }
        }
    }

   


}
