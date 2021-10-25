using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Credts : MonoBehaviour
{

    [SerializeField] Text smashBalls;
    [SerializeField] Text time;
    void Start()
    {
        smashBalls.text = CollectibleManager.smashBalls.ToString() + "/10";
        time.text = Timer.timeString.ToString();
    }
   void displayTime()
    {
        
    }

    void displayScore()
    {
        
    }
}
