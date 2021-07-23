using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpController : MonoBehaviour
{
    int maxHealth = 3;
    public float timeInvincible =1.0f;
    public Text lives;

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

        if (System.IO.File.Exists(Application.persistentDataPath + "/" + SaveManagement.instance.datas.saveName + ".save"))
        {
            SaveManagement.instance.Load();
            currentHealth = SaveManagement.instance.datas.lives;
            lives.text = currentHealth.ToString();
        }
        else
        {
            SaveManagement.instance.datas.lives = currentHealth;
            lives.text = currentHealth.ToString();
        }
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

        if(currentHealth <= 0)
        {
            GameManager.instance.reStart();
        }
    }

    public void ChangeHealth(int amount)
    {
        SoundController.instance.SetAudioSource("hurt");
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
        SaveManagement.instance.datas.lives = currentHealth;
        lives.text = currentHealth.ToString();
        Debug.Log(currentHealth + "/" + maxHealth);
    }

    public int getHealth { get { return currentHealth; } }
}
