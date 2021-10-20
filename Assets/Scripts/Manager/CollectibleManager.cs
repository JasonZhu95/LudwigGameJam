using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class CollectibleManager : MonoBehaviour
{
    public static CollectibleManager instance;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    
}
