using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotRealExit : MonoBehaviour
{
    public GameObject GM;
    public GameObject Father;

    public void Start()
    {
        GM = GameObject.Find("GM");
    }

    public void onNotRealExit()
    {
        GM.GetComponent<GM>().goingToExit = false;
    }

    public void FixedUpdate()
    {
        GetComponent<UIFade>().isOK = Father.GetComponent<UIFade>().isOK;
        GetComponent<UIFade>().isBack = Father.GetComponent<UIFade>().isBack;
    }
}
