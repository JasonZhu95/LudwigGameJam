using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyablePlats : MonoBehaviour
{
    private bool playerInRange;

    private GameObject player;
    public GameObject platformPosition;
    private Player playerScript;
    public GameObject breakAnimationEffect;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player>();
    }

    private void Update()
    {
        if (playerInRange && playerScript.DashState.isDashing)
        {
            Instantiate(breakAnimationEffect, platformPosition.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
