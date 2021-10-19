using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashBall : MonoBehaviour
{
    private GameObject player;
    private PlayerInputHandler pc;
     
    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerInputHandler>();

        if (collision.CompareTag("Player"))
        {
            pc.smashBalls++;
            Destroy(gameObject);
        }
    }
}
