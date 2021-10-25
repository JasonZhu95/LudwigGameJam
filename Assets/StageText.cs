using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageText : MonoBehaviour
{
    public static int currentStage;
    [SerializeField] Text stageText;
    MusicManager mm;
    private void Start()
    {
        mm = GameObject.FindGameObjectWithTag("Music Manager").GetComponent<MusicManager>();
        mm.StopMusic();
    }
    void Update()
    {
        stageText.text = currentStage.ToString() + "-2";
    }
}
