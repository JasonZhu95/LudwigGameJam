using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class top64Updater : MonoBehaviour
{
    public int nextLevelNum = 3;
    public static bool isTriggered = false;
    public static int id = 0;

    private void Awake()
    {

    }
    public void Start()
    {
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (isTriggered == false)
            {
                isTriggered = true;
                CollectibleManager.allowedNumOfSmashBalls += nextLevelNum;

                gameObject.SetActive(false);
            }
        }
    }
}
