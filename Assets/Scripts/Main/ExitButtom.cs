using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButtom : MonoBehaviour
{
    public GameObject GM;

    public GameObject Black;

    public void Start()
    {
        GM = GameObject.Find("GM");
    }

    public void OnExitGame()
    {
        GM.GetComponent<GM>().goingToExit = true;
    }

    public void FixedUpdate()
    {
        if (GM.GetComponent<GM>().goingToExit)
        {
            Black.SetActive(true);
        }
        else
        {
            Black.SetActive(false);
        }
    }
}
