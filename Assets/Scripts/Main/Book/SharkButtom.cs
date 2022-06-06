using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SharkButtom : MonoBehaviour
{
    public GameObject BookManager;

    public GameObject GM;

    public int maxChance = 5;
    public int nowChance;

    private void Start()
    {
        GM = GameObject.Find("GM");
        BookManager = GameObject.Find("BookManager");
    }

    public void Update()
    {
        nowChance = GM.GetComponent<GM>().Shark;
        if (nowChance <= maxChance)
        {
            gameObject.GetComponent<Image>().fillAmount = nowChance / maxChance;
        }
        else
        {
            gameObject.GetComponent<Image>().fillAmount = 1;
        }
    }

    public void OnToShark()
    {
        BookManager.GetComponent<BookManager>().Page = 4;
    }
}
