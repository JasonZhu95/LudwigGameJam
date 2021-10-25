using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMusic : MonoBehaviour
{
    //public string musicToStop;
    MusicManager mm;
    
    static int id = 0;
    void Start()
    {
        id++;
        mm = GameObject.FindGameObjectWithTag("Music Manager").GetComponent<MusicManager>();

        
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            mm.StopMusic();
           
        }
            
    }
}
