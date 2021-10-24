using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject player;
    private Vector2 targetPosition;
    private bool shouldFlip;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        targetPosition = new Vector2(player.transform.position.x, player.transform.position.y + 1f);

        StartCoroutine(LerpPosition(targetPosition, .1f));
        if (shouldFlip)
        {
            transform.rotation = Quaternion.Euler(0, 180f, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }

    IEnumerator LerpPosition(Vector2 targetPosition, float duration)
    {
        float time = 0;
        Vector2 startPosition = transform.position;
        if (startPosition.x - targetPosition.x < 0)
        {
            shouldFlip = true;
        }
        else
        {
            shouldFlip = false;
        }

        while (time < duration)
        {
            transform.position = Vector2.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }


}
