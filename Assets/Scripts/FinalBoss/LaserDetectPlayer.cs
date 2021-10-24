using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDetectPlayer : MonoBehaviour
{

    private Player player;
    private Transform firePointRotation;
    private void Start()
    {
        firePointRotation = GameObject.Find("FirePoint").GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Vector3 temp = firePointRotation.eulerAngles;
        gameObject.transform.eulerAngles = temp;
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
            player.GetComponent<PlayerStats>().Die();
            Destroy(gameObject);
        }
    }
}
