using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroductionTextFellow : MonoBehaviour
{
    public GameObject Master;

    void Update()
    {
        gameObject.GetComponent<UIFade>().isOK = Master.GetComponent<UIFade>().isOK;
        gameObject.GetComponent<UIFade>().isBack = Master.GetComponent<UIFade>().isBack;
    }
}
