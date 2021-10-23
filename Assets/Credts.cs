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
        smashBalls.text = PlayerInputHandler.smashBalls.ToString();
        time.text = Timer.timeString.ToString();
    }
   void displayTime()
    {
        
    }

    void displayScore()
    {
        
    }
}
