using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDetectPlayer : MonoBehaviour
{

    private Player player;
    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        StartCoroutine(DestroyLaser());
    }

    IEnumerator DestroyLaser()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
    }

    private void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            Debug.Log("Check");
            player.GetComponent<PlayerStats>().Die();
            Destroy(gameObject);
        }
    }
}
