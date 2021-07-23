using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController instance;

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip jump, hurt, diamond, cherry, coin, key;
    private void Awake()
    {
        instance = this;
    }

    public void SetAudioSource(string clipName)
    {
        switch (clipName)
        {
            case "jump":
                audioSource.clip = jump;
                break;
            case "hurt":
                audioSource.clip = hurt;
                break;
            case "diamond":
                audioSource.clip = diamond;
                break;
            case "cherry":
                audioSource.clip = cherry;
                break;
            case "coin":
                audioSource.clip = coin;
                break;
            case "key":
                audioSource.clip = key;
                break;
        }
        audioSource.Play();
    }

}
