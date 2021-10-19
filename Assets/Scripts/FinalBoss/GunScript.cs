using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public Transform target;

    private Vector2 direction;

    public GameObject gun;
    public GameObject laser;
    public Transform laserFirePoint;

    public float laserForce;

    private float detectRadius = 100f;
    public LayerMask whatIsPlayer;

    public float FireRate;
    private float nextTimetoFire = 0;


    private void Update()
    {
        Vector2 targetPos = target.position;

        direction = targetPos - (Vector2)transform.position;

        gun.transform.right = direction;
        if (gun.transform.rotation.eulerAngles.z <= 90.0f || gun.transform.rotation.eulerAngles.z >= 270.0f)
        {
            gun.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            gun.transform.localScale = new Vector3(1, -1, 1);
        }

        if (CheckForPlayer())
        {
            if (Time.time > nextTimetoFire)
            {
                nextTimetoFire = Time.time + 1 / FireRate;
                ShootLaser();
            }
        }
    }

    public bool CheckForPlayer()
    {
        return Physics2D.OverlapCircle(transform.position, detectRadius, whatIsPlayer);
    }

    private void ShootLaser()
    {
        GameObject LaserIns = Instantiate(laser, laserFirePoint.position, Quaternion.identity);
        LaserIns.GetComponent<Rigidbody2D>().AddForce(direction * laserForce);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, detectRadius);
    }
}
