using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip playerDeath;
    private static AudioSource audioSrc;

    private void Start()
    {
        playerDeath = Resources.Load<AudioClip>("playerDeath");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "playerDeath":
                audioSrc.PlayOneShot(playerDeath); 
                break;
        }
    }
}
