using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaA : MonoBehaviour
{
    public float X;

    public float Y;

    public float a = 0.00000001f;

    public float speed = 0;

    public bool isright = true;

    public float Updown = 0f;

    public Vector2 v2;

    public float B;

    void Start()
    {
        X = GetComponent<Transform>().position.x;
        B = 0.5f / 4;
    }

    void FixedUpdate()
    {
        if (X < 0)
        {
            isright = true;
            speed += a * Time.deltaTime * 0.001f;
        }
        if (X > 0)
        {
            isright = false;
            speed -= a * Time.deltaTime * 0.001f;
        }
        X += speed;
        Y = B * X * X - Updown;
        transform.position = new Vector2(X, Y);
    }
}
