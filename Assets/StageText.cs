using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageText : MonoBehaviour
{
    public static int currentStage;
    [SerializeField] Text stageText;
    
    void Update()
    {
        stageText.text = currentStage.ToString();
    }
}
