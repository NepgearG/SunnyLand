using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    protected AudioSource dead;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        dead = GetComponent<AudioSource>();
    }
    protected virtual void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dead.Play();
            Destroy(collision.gameObject);
            Invoke("reStart", 2f);
        }
    }

    public void reStart()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void Next()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("BossScene");
        }
    }
}
