using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopMusicDestroy : MonoBehaviour
{
    //public string musicToStop;
    MusicManager mm;

    static int id = 0;
    public static bool isTriggered = false;
    void Start()
    {
        
        mm = GameObject.FindGameObjectWithTag("Music Manager").GetComponent<MusicManager>();
        if (id > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            id++;
            DontDestroyOnLoad(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            mm.StopMusic();
            isTriggered = true;
            if (isTriggered == true)
            {
                gameObject.SetActive(false);
            }
        }

    }
}
