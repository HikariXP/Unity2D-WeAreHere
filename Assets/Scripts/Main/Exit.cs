using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public GameObject Father;

    public void onExit()
    {
        Application.Quit();
    }
    public void FixedUpdate()
    {
        GetComponent<UIFade>().isOK = Father.GetComponent<UIFade>().isOK;
        GetComponent<UIFade>().isBack = Father.GetComponent<UIFade>().isBack;
    }
}
