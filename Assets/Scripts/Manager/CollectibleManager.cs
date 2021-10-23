using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleManager : MonoBehaviour
{
    public Text numSmashBallsText;
    public int smashBallsInStage;
    public static int smashBalls = 0;
    public void Add()
    {
        smashBalls++;
    }




    public void Update()
    {
        numSmashBallsText.text = smashBalls.ToString();
    }

}
