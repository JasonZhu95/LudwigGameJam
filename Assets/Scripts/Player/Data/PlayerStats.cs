using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    private Player player;
    private Rigidbody2D RB;
    private GameManager GM;
    private GameObject spikeObject;
    public GameObject deathEffect;

    private bool isCollidingWithSpike;

    public static int totalLossCount = 0;
    public static int stockCount = 4;
    public int currentStocks;
    public Image[] stocks;
    private bool disableDie;
    public float halfGravThreshold;

    private void Start()
    {
        currentStocks = stockCount;
        player = GetComponent<Player>();
        RB = GetComponent<Rigidbody2D>();
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (!player.InputHandler.JumpInputStop && Mathf.Abs(player.RB.velocity.y) < halfGravThreshold)
        {
            player.RB.gravityScale = 2.5f;
        }
        else
        {
            player.RB.gravityScale = 5f;
        }

        if (SceneManager.GetActiveScene().buildIndex != 1)
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
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Obstacle"))
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Spike"))
        {
            spikeObject = coll.gameObject;
            isCollidingWithSpike = true;
        }

        if (coll.gameObject.CompareTag("DeathZone"))
        {
            Die();
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Spike"))
        {
            isCollidingWithSpike = false;
        }
    }

    public void Die()
    {
        if (!disableDie)
        {
            disableDie = true;
            SoundManagerScript.PlaySound("playerDeath");
            Destroy(gameObject);
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            if (SceneManager.GetActiveScene().buildIndex != 1)
            {
                stockCount--;
            }
            if (stockCount == 0)
            {
                totalLossCount++;
            }
            StartCoroutine(ReEnableDie());
            GM.Respawn();
        }
    }

    IEnumerator ReEnableDie()
    {
        yield return new WaitForSeconds(.15f);
        disableDie = false;
    }

    private void CheckSpikeCollision()
    {
        if (isCollidingWithSpike)
        {
            if (player.CheckIfTouchingWall())
            {
                Die();
            }
            if (spikeObject.transform.rotation.eulerAngles.z == 90)
            {
                if (RB.velocity.x < 0.01) { }
                else
                {
                    Die();
                }
            }
            // Facing Down
            else if (spikeObject.transform.rotation.eulerAngles.z == 180)
            {
                if (RB.velocity.y < 0.01) { }
                else
                {
                    Die();
                }
            }
            // Facing Right
            else if (spikeObject.transform.rotation.eulerAngles.z == 270)
            {
                if (RB.velocity.x > 0.01) { }
                else
                {
                    Die();
                }
            }
            // Facing Up
            else if (spikeObject.transform.rotation.eulerAngles.z == 0)
            {
                if (RB.velocity.y > 0.01) { }
                else
                {
                    Die();
                }
            }
        }
    }
}
