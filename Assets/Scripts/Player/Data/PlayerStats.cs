using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    private Rigidbody2D RB;
    private GameManager GM;
    private GameObject spikeObject;
    public GameObject deathEffect;

    private bool isCollidingWithSpike;

    public static int stockCount = 4;
    public int currentStocks;
    public Image[] stocks;


    private void Start()
    {
        currentStocks = stockCount;
        RB = GetComponent<Rigidbody2D>();
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
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
        CheckSpikeCollision();
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Equals("Obstacle"))
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("Spike"))
        {
            spikeObject = coll.gameObject;
            isCollidingWithSpike = true;
        }

        if (coll.gameObject.tag.Equals("DeathZone"))
        {
            Die();
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("Spike"))
        {
            isCollidingWithSpike = false;
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        stockCount--;
        if (stockCount == 0)
        {
            stockCount = 4;
        }
        GM.Respawn();
    }

    private void CheckSpikeCollision()
    {
        if (isCollidingWithSpike)
        {
            if (spikeObject.transform.rotation.eulerAngles.z == 90)
            {
                if (RB.velocity.x <= 0.0) { }
                else
                {
                    Die();
                }
            }
            // Facing Down
            else if (spikeObject.transform.rotation.eulerAngles.z == 180)
            {
                if (RB.velocity.y <= 0.0) { }
                else
                {
                    Die();
                }
            }
            // Facing Right
            else if (spikeObject.transform.rotation.eulerAngles.z == 270)
            {
                if (RB.velocity.x >= 0.0) { }
                else
                {
                    Die();
                }
            }
            // Facing Up
            else
            {
                if (RB.velocity.y >= 0.0) { }
                else
                {
                    Die();
                }
            }
        }
    }
}
