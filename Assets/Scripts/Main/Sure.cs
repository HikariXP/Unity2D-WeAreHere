using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sure : MonoBehaviour
{
    public GameObject GM;

    public void Start()
    {
        GM = GameObject.Find("GM");
    }

    public void SureOk()
    {
        GM.GetComponent<GM>().isFirstPlaying = false;
        GM.GetComponent<GM>().isIntroducing = false;
        GM.GetComponent<GM>().isbusy = false;
    }
}
