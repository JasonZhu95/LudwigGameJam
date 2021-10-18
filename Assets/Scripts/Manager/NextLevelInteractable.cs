using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NextLevelInteractable : MonoBehaviour
{
    private GameManager GM;
    private PlayerInputHandler playerInput;

    private bool playerInRange;

    private void Awake()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Start()
    {
        playerInput = GameObject.Find("Player").GetComponent<PlayerInputHandler>();
    }


    private void Update()
    {
        if (playerInRange && playerInput.InteractInput)
        {
            GM.LoadNextLevel();
        }

        if (playerInRange)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
