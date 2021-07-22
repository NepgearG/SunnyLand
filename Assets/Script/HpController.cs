using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpController : MonoBehaviour
{
    public int maxHealth = 1;
    public int getHealth { get { return currentHealth; } }
    public float timeInvincible =1.0f;
    public AudioSource hurtAudio;

    Animator animator;
    int currentHealth;
    bool isInvincible;
    float InvincibleTimer;
    MovementController movement;
    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<MovementController>();
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isInvincible)
        {
            InvincibleTimer -= 3f *Time.deltaTime;
            if(InvincibleTimer < 0)
            {
                isInvincible = false;
                animator.SetBool("IsHurt", false);
                movement.setBattle(false) ;
            }
        }
    }

    public void ChangeHealth(int amount)
    {
        hurtAudio.Play();
        if (amount < 0)
        {
            if (isInvincible)
            {
                return;
            }

            isInvincible = true;
            InvincibleTimer = timeInvincible;
            animator.SetBool("IsHurt", true);
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
