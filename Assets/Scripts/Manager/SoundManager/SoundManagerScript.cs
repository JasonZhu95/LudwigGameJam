using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip playerDeath;
    public static AudioClip playerDash;
    public static AudioClip playerLand;
    public static AudioClip playerJump;
    public static AudioClip trampoline;
    private static AudioSource audioSrc;

    private void Start()
    {
        playerDeath = Resources.Load<AudioClip>("playerDeath");
        playerDash = Resources.Load<AudioClip>("playerDash");
        playerLand = Resources.Load<AudioClip>("playerLand");
        playerJump = Resources.Load<AudioClip>("playerJump");
        trampoline = Resources.Load<AudioClip>("trampoline");

        audioSrc = GetComponent<AudioSource>();
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            
            case "playerDeath":
                audioSrc.PlayOneShot(playerDeath, 0.2f); 
                break;
            case "trampoline":
                audioSrc.PlayOneShot(trampoline);
                break;
            case "playerDash":
                audioSrc.PlayOneShot(playerDash, 0.2f);
                break;
            case "playerLand":
                audioSrc.PlayOneShot(playerLand, 0.05f);
                break;
            case "playerJump":
                audioSrc.PlayOneShot(playerJump,1f);
                break;
            default:
                break;
        }
    }
}
