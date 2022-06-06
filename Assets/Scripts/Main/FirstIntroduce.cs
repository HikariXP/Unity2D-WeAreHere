using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstIntroduce : MonoBehaviour
{
    public GameObject GM;

    public GameObject SureButtom;

    public void Start()
    {
        GM = GameObject.Find("GM");
    }

    public void Update()
    {
        if (GM.GetComponent<GM>().isFirstPlaying)
        {
            if (GM.GetComponent<GM>().isMainLoaded)
            {
                GM.GetComponent<GM>().isIntroducing = true;
                GM.GetComponent<GM>().isbusy = true;
            }
        }
        if (GM.GetComponent<GM>().isIntroducing)
        {
            gameObject.GetComponent<UIFade>().isOK = true;
            gameObject.GetComponent<UIFade>().isBack = false;
            SureButtom.GetComponent<UIFade>().isBack = false;
            SureButtom.GetComponent<UIFade>().isOK = true;
        }
        else
        {
            SureButtom.GetComponent<UIFade>().isBack = true;
            SureButtom.GetComponent<UIFade>().isOK = false;
            gameObject.GetComponent<UIFade>().isOK = false;
            gameObject.GetComponent<UIFade>().isBack = true;
        }
    }
}
