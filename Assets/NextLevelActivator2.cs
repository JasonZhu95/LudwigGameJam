using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelActivator2 : MonoBehaviour
{
    private GameManager GM;
    private float timer = 0f;
    private void Awake()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.5f)
        {
            GM.LoadNextLevel();
            timer = 0f;
        }
    }
}
