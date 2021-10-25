using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageText1 : MonoBehaviour
{
    public static int currentStage;
    [SerializeField] Text stageText1;
    //MusicManager mm;
    private void Start()
    {
        
    }
    void Update()
    {
        
        stageText1.text = currentStage.ToString() + "-1";
    }
}
