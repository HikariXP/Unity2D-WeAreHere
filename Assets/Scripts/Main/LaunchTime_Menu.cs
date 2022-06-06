using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaunchTime_Menu: MonoBehaviour
{
    public GameObject GM;

    public void Start()
    {
        GM = GameObject.Find("GM");    
    }

    public void Update()
    {
        gameObject.GetComponent<Text>().text = "航行次数:"+GM.GetComponent<GM>().launchTime ;
    }
}
