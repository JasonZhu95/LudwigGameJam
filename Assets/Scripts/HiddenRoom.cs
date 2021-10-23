using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HiddenRoom : MonoBehaviour
{
    private Tilemap tilecolor;

    private void Start()
    {
        tilecolor = GetComponent<Tilemap>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            StartCoroutine(FadeTo(0.5f, 1.0f));
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            StartCoroutine(FadeTo(1.0f, 1.0f));
        }
    }

    IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = tilecolor.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            tilecolor.color = newColor;
            yield return null;
        }
    }
}