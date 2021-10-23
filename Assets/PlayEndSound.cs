using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayEndSound : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            SoundManagerScript.PlaySound("creditSound");
        }
    }
}
