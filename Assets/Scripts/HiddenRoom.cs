using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenRoom : MonoBehaviour
{
    private SpriteRenderer sprite;
    public GameObject smashBall;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        smashBall.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            StartCoroutine(FadeTo(0.5f, 1.0f));
            smashBall.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            StartCoroutine(FadeTo(1.0f, 1.0f));
            smashBall.SetActive(false);
        }
    }

    IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = sprite.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            sprite.color = newColor;
            yield return null;
        }
    }
}