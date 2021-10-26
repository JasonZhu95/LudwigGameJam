using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageText1 : MonoBehaviour
{
    [SerializeField] Text stageText1;
    //MusicManager mm;
    private void Start()
    {
        
    }
    void Update()
    {
        
        stageText1.text = StageText.currentStage.ToString() + "-1";
    }
}
