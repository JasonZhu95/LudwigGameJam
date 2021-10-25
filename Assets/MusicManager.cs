using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    public  AudioSource music;
    public  AudioClip opSound;
    public  AudioClip poolsSound;
    [SerializeField] public static string musicToPlay;
    private int current = -1;
    

    public static bool playOpSound;
    public static bool playPoolsSound;


    private void Start()
    {
        opSound = Resources.Load<AudioClip>("opSound");
        poolsSound = Resources.Load<AudioClip>("poolsSound");
        if (FindObjectsOfType(typeof(MusicManager)).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

        music = gameObject.GetComponent<AudioSource>();
        
    }

    public void ChangeMusic()
    {
        
        
    }
    void Update()
    {
        if(musicToPlay == "opSound")
        {
            if (current != 0)
            {
                current = 0;
                music.clip = opSound;
                music.Play();
            }
        }
        else if(musicToPlay == "poolsSound")
        {
            if(current != 1)
            {
                current = 1;
                music.clip = poolsSound;
                music.Play();
            }
        }
       
    }
    public void PlayMusic(string clip)
    { 
        musicToPlay = clip;
    }
    public void StopMusic()
    {
        music.Stop();
    }
}
