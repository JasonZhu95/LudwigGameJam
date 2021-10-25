using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelIncreaseCount : MonoBehaviour
{
    private GameManager GM;

    private void Awake()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            //SmashBall.objectID = 0;
            StageText.currentStage++;
            GM.LoadNextLevel();
        }
    }
}
