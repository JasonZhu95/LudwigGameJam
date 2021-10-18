using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InRangeActivator : MonoBehaviour
{
    private bool playerInRange;

    private void Update()
    {
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
