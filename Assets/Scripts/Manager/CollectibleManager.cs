using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class CollectibleManager : MonoBehaviour
{
    public static CollectibleManager instance;
    public TextMeshProUGUI text;
    private int collectibleCount;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void ChangeCount(int count)
    {
        collectibleCount = count;
        text.text = "X" + collectibleCount.ToString();
    }
}
