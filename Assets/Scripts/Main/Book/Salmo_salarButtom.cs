using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Salmo_salarButtom : MonoBehaviour
{
    public GameObject BookManager;

    public GameObject GM;

    public float maxChance = 20;
    public float nowChance;

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

    public void OnToSalmo_salar()
    {
        BookManager.GetComponent<BookManager>().Page = 3;
    }
}
