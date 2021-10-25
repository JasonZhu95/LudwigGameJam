using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelActivator1 : MonoBehaviour
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
        if (timer > 2f)
        {
            GM.LoadSavedLevel();
            timer = 0f;
        }
    }
}
