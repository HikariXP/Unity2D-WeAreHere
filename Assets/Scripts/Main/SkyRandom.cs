using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyRandom : MonoBehaviour
{
    public GameObject GM;

    public Sprite Sky1;
    public Sprite Sky2;
    public Sprite Sky3;
    public Sprite Sky4;

    public void Start()
    {
        GM = GameObject.Find("GM");
    }

    void Update()
    {
        switch (GM.GetComponent<GM>().skyNumber)
        {
            case 1: GetComponent<SpriteRenderer>().sprite = Sky1;break;
            case 2: GetComponent<SpriteRenderer>().sprite = Sky2; break;
            case 3: GetComponent<SpriteRenderer>().sprite = Sky3; break;
            case 4: GetComponent<SpriteRenderer>().sprite = Sky4; break;
        }
    }
}
