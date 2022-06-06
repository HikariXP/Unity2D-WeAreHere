using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pops : MonoBehaviour
{
    public GameObject Player;

    public float speed = 0;

    public float a = 1;

    public float Maxspeed = 2.5f;

    public void Awake()
    {
        Player = GameObject.Find("FishingMachine");
        gameObject.transform.position = Player.transform.position;
    }

    public void FixedUpdate()
    {
        if (gameObject.transform.position.y >= 70)
        {
            Destroy(gameObject);
        }
        else
        {
            if (speed <= Maxspeed)
            {
                speed += Time.deltaTime * a;
                transform.position = new Vector2(gameObject.transform.position.x ,speed * Time.deltaTime);
            }
        }
    }
}
