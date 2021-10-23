using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    public static Timer instance;
    public static string timeString;

    public Text timerText;

    private TimeSpan timePlaying;
    private bool timerGoing;

    private float elapsedTime;


    private void Awake()
    {
        instance = this;
        
    }

    private void Start()
    {
        timerGoing = false;
    }

    public void BeginTimer()
    {
        timerGoing = true;
        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timerGoing = false;
    }

    private IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = timePlaying.ToString("mm':'ss'.'ff");
            timerText.text = timePlayingStr;
            
            yield return null;
            timeString = timePlayingStr;
        }
        
    }
}
