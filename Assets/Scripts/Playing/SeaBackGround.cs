using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaBackGround : MonoBehaviour
{
    public GameObject GM;

    public GameObject Player;

    public float yspeed;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GM");
        Player = GameObject.Find("FishingMachine");
        switch (GM.GetComponent<GM>().seaId)
        {
            case 1:
                GetComponent<SpriteRenderer>().sprite = GM.GetComponent<GM>().maps[0].map; break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GM.GetComponent<GM>().isGameStart)
        {
            transform.position = new Vector3(Player.GetComponent<Transform>().position.x, Player.GetComponent<Transform>().position.y*yspeed, 0);
        }
    }
}
