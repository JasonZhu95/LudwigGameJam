using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularObstacle : MonoBehaviour
{
    public float RotateSpeed = 5f;
    public float Radius = 1f;

    private Vector2 center;
    private float angle;

    private void Start()
    {
        center = transform.position;
    }

    private void Update()
    {
        angle += RotateSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * Radius;
        transform.position = center + offset;
    }
}
