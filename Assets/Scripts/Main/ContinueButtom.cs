using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButtom : MonoBehaviour
{
    public GameObject GM;
    public void Start()
    {
        GM = GameObject.Find("GM");
    }
    public void OnContinueGame()
    {
        GM.GetComponent<GM>().isPause = false;
        GM.GetComponent<GM>().goingToExit = false;
        GM.GetComponent<GM>().isbusy = false;
        GM.GetComponent<GM>().isBookIng = false;
    }
}
