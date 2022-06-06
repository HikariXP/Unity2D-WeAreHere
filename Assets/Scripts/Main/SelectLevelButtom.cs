using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevelButtom : MonoBehaviour
{
    public GameObject GM;

    public int seaNumber;

    public void Start()
    {
        GM = GameObject.Find("GM");
    }
    public void OnSelectLevel()
    {
        GM.GetComponent<GM>().seaId = seaNumber;
        GM.GetComponent<GM>().isbusy = false;
        GM.GetComponent<GM>().isSelectLevel = false;
    }
}
