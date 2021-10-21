using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyTimer : MonoBehaviour
{
    public static int id = 0;

    private void Awake()
    {
        id++;
    }
    public void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (FindObjectsOfType(typeof(DontDestroyTimer)).Length > 1)
        {
            DestroyImmediate(gameObject);
        }
        
    }
}