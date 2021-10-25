using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip playerDeath;
    public static AudioClip playerRevive;
    public static AudioClip playerDash;
    public static AudioClip playerLand;
    public static AudioClip playerJump;
    public static AudioClip trampoline;
    public static AudioClip bossShine;
    public static AudioClip bossLaser;
    private static AudioSource audioSrc;
    private static AudioClip creditSound;

    private void Start()
    {
        playerDeath = Resources.Load<AudioClip>("playerDeath");
        playerRevive = Resources.Load<AudioClip>("playerRevive");
        playerDash = Resources.Load<AudioClip>("playerDash");
        playerLand = Resources.Load<AudioClip>("playerLand");
        playerJump = Resources.Load<AudioClip>("playerJump");
        trampoline = Resources.Load<AudioClip>("trampoline");
        creditSound = Resources.Load<AudioClip>("creditSound");
        bossShine = Resources.Load<AudioClip>("bossShine");
        bossLaser = Resources.Load<AudioClip>("bossLaser");

        audioSrc = GetComponent<AudioSource>();
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            
            case "playerDeath":
                audioSrc.PlayOneShot(playerDeath, 0.2f); 
                break;
            case "playerRevive":
                audioSrc.PlayOneShot(playerRevive, 0.2f);
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
            case "bossShine":
                audioSrc.PlayOneShot(bossShine, .1f);
                break;
            case "bossLaser":
                audioSrc.PlayOneShot(bossLaser, .1f);
                break;
            case "creditSound":
                audioSrc.PlayOneShot(creditSound, .05f);
                break;
            default:
                break;
        }
    }
}
