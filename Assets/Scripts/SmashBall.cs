using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SmashBall : MonoBehaviour
{
    private GameObject player;
    private PlayerInputHandler pc;
    public static SmashBall instance;
    

    private void Awake()
    {
       
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerInputHandler>();

        if (collision.CompareTag("Player"))
        {
            PlayerInputHandler.smashBalls++;
            gameObject.SetActive(false);
        }
    }

}
