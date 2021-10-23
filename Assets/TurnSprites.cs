using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSprites : MonoBehaviour
{
    private GameObject player;
    public float xPos;
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        
    }

    void Update()
    {
        xPos = player.GetComponent<Transform>().position.x;

        if (xPos < gameObject.GetComponent<Transform>().position.x)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}
