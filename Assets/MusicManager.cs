using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    public  AudioSource music;
    public  AudioClip opSound;
    public  AudioClip poolsSound;
    public AudioClip breakSound;
    public AudioClip top64Sound;
    public AudioClip top8Sound;
    public AudioClip bossSound;
    public static string musicToPlay;
    private static int current = -3;
    

    


    private void Start()
    {
        opSound = Resources.Load<AudioClip>("opSound");
        poolsSound = Resources.Load<AudioClip>("poolsSound");
        breakSound = Resources.Load<AudioClip>("breakSound");
        top64Sound = Resources.Load<AudioClip>("top64Sound");
        top8Sound = Resources.Load<AudioClip>("top8Sound");
        bossSound = Resources.Load<AudioClip>("bossSound");
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
        if(current != -2)
        {
            if (musicToPlay == "opSound")
            {
                if (current == 0)
                {
                    current = -1;
                    music.clip = opSound;
                    music.Play();
                }
            }
            else if (musicToPlay == "poolsSound")
            {
                if (current == 1)
                {
                    current = -1;
                    music.clip = poolsSound;
                    music.Play();
                }
            }
            else if (musicToPlay == "breakSound")
            {
                if(current == 2)
                {
                    current = -1;
                    music.clip = breakSound;
                    music.Play();
                }
            }
            else if (musicToPlay == "top64Sound")
            {
                if (current == 3)
                {
                    current = -1;
                    music.clip = top64Sound;
                    
                    music.Play();
                }
            }
            else if (musicToPlay == "top8Sound")
            {
                if (current == 4)
                {
                    current = -1;
                    music.clip = top8Sound;

                    music.Play();
                }
            }
            else if (musicToPlay == "bossSound")
            {
                if (current == 5)
                {
                    current = -1;
                    music.clip = bossSound;

                    music.Play();
                }
            }

        }
        
    }
    public void PlayMusic(string clip)
    {
        if(current != -1)
        {
            if (clip == "opSound")
            {
                current = 0;
            }
            else if (clip == "poolsSound")
            {
                current = 1;
            }
            else if(clip == "breakSound")
            {
                current = 2;
                music.volume = 0.022f;
            }
            else if (clip == "top64Sound")
            {
                current = 3;
                music.volume = 0.038f;
            }
            else if (clip == "top8Sound")
            {
                current = 4;
                music.volume = 0.022f;
            }
            else if (clip == "bossSound")
            {
                current = 5;
                
            }
        }
        
        musicToPlay = clip;
    }
    public void StopMusic()
    {
        current = -2;
        music.Stop();
        
    }
}
