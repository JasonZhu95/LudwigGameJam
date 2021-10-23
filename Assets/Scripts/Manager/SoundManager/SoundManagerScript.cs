using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip playerDeath;
    public static AudioClip playerDash;
    public static AudioClip playerMove;
    public static AudioClip trampoline;
    private static AudioSource audioSrc;

    private void Start()
    {
        playerDeath = Resources.Load<AudioClip>("playerDeath");
        playerDash = Resources.Load<AudioClip>("playerDash");
        playerMove = Resources.Load<AudioClip>("playerMove");
        trampoline = Resources.Load<AudioClip>("trampoline");

        audioSrc = GetComponent<AudioSource>();
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            
            case "playerDeath":
                audioSrc.PlayOneShot(playerDeath, 0.5f); 
                break;
            case "trampoline":
                audioSrc.PlayOneShot(trampoline);
                break;
            case "playerDash":
                audioSrc.PlayOneShot(playerDash, 0.5f);
                break;
            default:
                break;
        }
    }
}
