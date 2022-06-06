using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlaying : MonoBehaviour
{
    public GameObject GM;

    public GameObject Player;

    void Start()
    {
        GM = GameObject.Find("GM");
        Player = GameObject.Find("FishingMachine");
    }

    // Update is called once per frame
    void Update()
    {
        if (GM.GetComponent<GM>().isGameStart)
        {
            Player.GetComponent<Rigidbody2D>().gravityScale = 0.3f;
            transform.position = new Vector3(Player.GetComponent<Transform>().position.x, Player.GetComponent<Transform>().position.y, -10);
        }
    }
}
