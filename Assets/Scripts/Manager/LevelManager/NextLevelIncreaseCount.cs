using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelIncreaseCount : MonoBehaviour
{
    private GameManager GM;
    private bool disableOnTrigger;

    private void Awake()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player") && !disableOnTrigger)
        {
            //SmashBall.objectID = 0;
            disableOnTrigger = true;
            StageText.currentStage++;
            PlayerStats.totalLossCount = 0;
            GM.LoadNextLevel();
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {

    }
}
