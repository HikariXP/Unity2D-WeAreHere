using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishHaveFound_Menu : MonoBehaviour
{
    public GameObject GM;

    void Start()
    {
        GM = GameObject.Find("GM");
    }

    void Update()
    {
        gameObject.GetComponent<Text>().text = "已经扫描鱼类:" + GM.GetComponent<GM>().fishHaveFound;
    }
}
