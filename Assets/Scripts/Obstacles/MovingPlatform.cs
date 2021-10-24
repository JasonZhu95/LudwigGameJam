using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject platformPathStart;
    public GameObject platformPathEnd;

    private Player player;

    public float speed = 10f;
    public float speedBack = 5f;
    public float velocityDampener = 0.75f;
    private Vector3 startPosition;
    private Vector3 endPosition;
    public Vector3 platformVelocityTracker;
    private bool playerIsOnPlatform;

    private void Start()
    {
        startPosition = platformPathStart.transform.position;
        endPosition = platformPathEnd.transform.position;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        if (playerIsOnPlatform)
        {
            if (transform.position == startPosition)
            {
                StartCoroutine(LerpVector3(gameObject, endPosition, speed));
            }
        }
        if (transform.position == endPosition)
        {
            StartCoroutine(LerpVector3(gameObject, startPosition, speedBack));
        }
    }

    IEnumerator LerpVector3(GameObject obj, Vector3 target, float speed)
    {
        Vector3 startPosition = obj.transform.position;
        float time = 0f;
        float startTime = 0.0f;

        while (obj.transform.position != target)
        {
            if (playerIsOnPlatform && (player.JumpState.isJumping || player.WallJumpState.isWallJumping))
            {
                if (player.JumpState.isJumping)
                {
                    playerIsOnPlatform = false;
                }
                platformVelocityTracker = (obj.transform.position - startPosition) / (time - startTime);
                platformVelocityTracker *= velocityDampener;
                if (platformVelocityTracker.y >= 0)
                {
                    StartCoroutine(DisableVelocitySet());
                    player.RB.velocity = new Vector2(player.RB.velocity.x + platformVelocityTracker.x, player.RB.velocity.y + platformVelocityTracker.y);
                }
            }
            obj.transform.position = Vector3.Lerp(startPosition, target,
                (time / Vector3.Distance(startPosition, target)) * speed);
            time += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator DisableVelocitySet()
    {
        player.GetComponent<Player>().disableVelocitySet = true;
        yield return new WaitForSeconds(.2f);
        player.GetComponent<Player>().disableVelocitySet = false;
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            coll.gameObject.transform.SetParent(gameObject.transform, true);
            if (player.CheckIfGrounded())
            {
                playerIsOnPlatform = true;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D coll)
    {
        if (player.CheckIfGrounded())
        {
            playerIsOnPlatform = true;
        }
    }

    private void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            coll.gameObject.transform.parent = null;
            playerIsOnPlatform = false;
        }
    }
}
