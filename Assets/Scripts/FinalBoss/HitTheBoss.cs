using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitTheBoss : MonoBehaviour
{
    private GameObject player;
    private Player playerController;
    private GunScript gunScript;
    public GameObject deathEffect;

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

    public GameObject[] destroyPlatforms;

    public GameObject[] activeRooms;
    public static int amountOfTimesHit;

    public static int stockCount = 4;
    public int currentStocks;
    public Image[] stocks;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gunScript = GetComponent<GunScript>();
        playerController = player.GetComponent<Player>();
        playerTargetSelector = playerTargetPosition[0];
        currentStocks = stockCount;
    }

    private void Update()
    {
        for (int i = 0; i < stocks.Length; i++)
        {
            for
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
            stockCount--;
            startPosition = player.transform.position;
            bossStartPosition = transform.position;
            Destroy(destroyPlatforms[amountOfTimesHit]);
            Instantiate(deathEffect, destroyPlatforms[amountOfTimesHit].transform.position, Quaternion.identity);
            bossTargetSelector = bossTargetPosition[amountOfTimesHit];
            playerTargetSelector = playerTargetPosition[amountOfTimesHit];
            amountOfTimesHit++;

            startTimer = true;
        }
    }
}
