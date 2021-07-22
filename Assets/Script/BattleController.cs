using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    [Header("vars")]
    public float shift = 2;
    public float jumpForce = 0.8f;

    //status
    bool isBattle;

    Rigidbody2D rb;
    Animator playerAnimator;
    HpController hpController;

    // Start is called before the first frame update
    void Start()
    {
        hpController = GetComponent<HpController>();
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            setBattle(true);
            EnemyController enemyController = collision.gameObject.GetComponent<EnemyController>();
            if (collision.contacts[0].normal.y != 1)
            {
                enemyController.setDeathFlag();
                playerAnimator.SetBool("IsJump", true);
                rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y * jumpForce); 
            }
            else if (transform.position.x < collision.gameObject.transform.position.x)
            {
                hpController.ChangeHealth(-1);
                rb.velocity = new Vector2(-10, rb.velocity.y);
            }
            else if (transform.position.x > collision.gameObject.transform.position.x)
            {
                hpController.ChangeHealth(-1);
                rb.velocity = new Vector2(10, rb.velocity.y);
            }
            setBattle(false);
        }
    }

    //set battle status
    public void setBattle(bool status)
    {
        isBattle = status;
    }


}
