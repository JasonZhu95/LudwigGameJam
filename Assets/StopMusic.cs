using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMusic : MonoBehaviour
{
    //public string musicToStop;
    MusicManager mm;
    public static bool stopped = false;
    static int id = 0;
    void Start()
    {
        id++;
        mm = GameObject.FindGameObjectWithTag("Music Manager").GetComponent<MusicManager>();

        if (id > 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            stopped = true;
            mm.StopMusic();
            Destroy(gameObject);
        }
            
    }
}
