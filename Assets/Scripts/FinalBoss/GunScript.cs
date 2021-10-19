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

    private float nextTimetoFire = 0;

    private SpriteRenderer BossSprite;

    public float period = 5f;



    private void Start()
    {
        BossSprite = GameObject.Find("FinalBoss").GetComponent<SpriteRenderer>();
    }

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
                nextTimetoFire += period;
                StartCoroutine(ShootLaser());
            }
        }
    }

    public bool CheckForPlayer()
    {
        return Physics2D.OverlapCircle(transform.position, detectRadius, whatIsPlayer);
    }

    IEnumerator ShootLaser()
    {
        BossSprite.color = new Color(1, 0, 0);
        yield return new WaitForSeconds(1.5f);
        GameObject LaserIns = Instantiate(laser, laserFirePoint.position, Quaternion.identity);
        LaserIns.GetComponent<Rigidbody2D>().AddForce(direction * laserForce);
        yield return new WaitForSeconds(.3f);
        GameObject LaserIns2 = Instantiate(laser, laserFirePoint.position, Quaternion.identity);
        LaserIns2.GetComponent<Rigidbody2D>().AddForce(direction * laserForce);
        yield return new WaitForSeconds(.3f);
        GameObject LaserIns3 = Instantiate(laser, laserFirePoint.position, Quaternion.identity);
        LaserIns3.GetComponent<Rigidbody2D>().AddForce(direction * laserForce);
        BossSprite.color = new Color(1, 1, 1);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, detectRadius);
    }
}
