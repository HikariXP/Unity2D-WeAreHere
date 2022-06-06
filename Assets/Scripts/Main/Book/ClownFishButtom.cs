using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClownFishButtom : MonoBehaviour
{
    public GameObject BookManager;

    public GameObject GM;

    public float maxChance = 10;
    public float nowChance = 0;

    public void Awake()
    {
        GM = GameObject.Find("GM");
        BookManager = GameObject.Find("BookManager");
        nowChance = GM.GetComponent<GM>().ClownFish;
    }



    public void Update()
    {
        if (nowChance <= maxChance)
        {
            GetComponent<Image>().fillAmount = nowChance / maxChance;
        }
        else
        {
            gameObject.GetComponent<Image>().fillAmount = 1;
        }
    }

    public void OnToClownFish()
    {
        BookManager.GetComponent<BookManager>().Page = 2;
    }
}
