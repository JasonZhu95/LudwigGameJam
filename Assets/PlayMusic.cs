using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    MusicManager mm;
    public string musicToPlay;
    void Start()
    {
        mm = GameObject.FindGameObjectWithTag("Music Manager").GetComponent<MusicManager>();
    }
    
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            mm.PlayMusic(musicToPlay);
        }
    }
}
