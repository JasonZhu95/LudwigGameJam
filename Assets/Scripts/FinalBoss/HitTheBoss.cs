using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitTheBoss : MonoBehaviour
{
    private GameObject player;

    private GunScript gunScript;
    private Vector3 startPosition;
    private Vector3 bossStartPosition;
    public float timeToReachTarget;
    public float bossTimeToReachTarget;
    private float playerT;
    private float bossT;
    private bool startTimer;
    public GameObject[] playerTargetPosition;
    public GameObject[] bossTargetPosition;
    private GameObject bossTargetSelector;
    private GameObject playerTargetSelector;
    public GameObject deathEffect;

    public GameObject[] destroyPlatforms;

    public GameObject[] activeRooms;
    public static int amountOfTimesHit;

    public static int bossStockCount = 4;
    public static int destroyedPlatformsCount;
    public int currentStocks;
    public Image[] stocks;
    public static float bossPosX;
    public static float bossPosY;

    private void Start()
    {
        if (amountOfTimesHit != 0)
        {
            bossPosX = bossTargetPosition[amountOfTimesHit - 1].transform.position.x;
            bossPosY = bossTargetPosition[amountOfTimesHit - 1].transform.position.y;
            transform.position = new Vector3(bossPosX, bossPosY, transform.position.z);
        }

        for (int i = 0; i < destroyedPlatformsCount; i++)
        {
            Destroy(destroyPlatforms[i]);
        }

        player = GameObject.FindGameObjectWithTag("Player");
        gunScript = GetComponent<GunScript>();
        playerTargetSelector = playerTargetPosition[0];
        currentStocks = bossStockCount;
    }

    private void Update()
    {
        for (int i = 0; i < stocks.Length; i++)
        {
            if (i < currentStocks)
            {
                stocks[i].enabled = true;
            }
            else
            {
                stocks[i].enabled = false;
            }
        }
        if (startTimer)
        {
            playerT += Time.deltaTime / timeToReachTarget;
            bossT += Time.deltaTime / bossTimeToReachTarget;

            player.transform.position = Vector3.Lerp(startPosition, playerTargetSelector.transform.position, playerT);
            transform.position = Vector3.Lerp(bossStartPosition, bossTargetSelector.transform.position, bossT);
        }

        if (player.transform.position == playerTargetSelector.transform.position)
        {
            startTimer = false;
        }
        if (!activeRooms[amountOfTimesHit].activeSelf)
        {
            gunScript.waitingTime = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            startPosition = player.transform.position;
            bossStartPosition = transform.position;
            Destroy(destroyPlatforms[amountOfTimesHit]);
            destroyedPlatformsCount++;

            bossTargetSelector = bossTargetPosition[amountOfTimesHit];
            playerTargetSelector = playerTargetPosition[amountOfTimesHit];
            bossStockCount--;
            amountOfTimesHit++;
            if (amountOfTimesHit == 4)
            {
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

            startTimer = true;
        }
    }
}
