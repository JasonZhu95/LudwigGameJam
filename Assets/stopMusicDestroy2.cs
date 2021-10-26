using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopMusicDestroy2 : MonoBehaviour
{
    //public string musicToStop;
    MusicManager mm;

    static int id = 0;
    public static bool isTriggered = false;
    void Start()
    {

        mm = GameObject.FindGameObjectWithTag("Music Manager").GetComponent<MusicManager>();


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (isTriggered == false)
            {
                mm.StopMusic();
                isTriggered = true;
                gameObject.SetActive(false);
            }
        }
    }
}
