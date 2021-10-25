using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poolsUpdater : MonoBehaviour
{
    public int nextLevelNum = 3;
    public static bool acquired = false;
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
