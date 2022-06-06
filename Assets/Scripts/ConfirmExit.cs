using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmExit : MonoBehaviour
{
    public GameObject GM;

    public void Start()
    {
        GM = GameObject.Find("GM");
    }

    public void Update()
    {
        if (GM.GetComponent<GM>().goingToExit)
        {
            GetComponent<UIFade>().isOK = true;
        }
        if (!GM.GetComponent<GM>().goingToExit)
        {
            if (GetComponent<UIFade>().isBack == false)
            {
                GetComponent<UIFade>().isBack = true;
            }
        }
    }
}
