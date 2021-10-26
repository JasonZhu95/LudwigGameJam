using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poolsUpdater : MonoBehaviour
{
    public int nextLevelNum = 3;
    public static bool acquired = false;
    public static int id = 0;

    private void Awake()
    {
        id++;
    }
    public void Start()
    {
        if (id > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

        void OnTriggerEnter2D(Collider2D other)
         {
            if (other.CompareTag("Player"))
            {
                acquired = true;
                CollectibleManager.allowedNumOfSmashBalls += nextLevelNum;
                if (acquired == true)
                {
                    Destroy(gameObject);
                }
            }
        }
}
