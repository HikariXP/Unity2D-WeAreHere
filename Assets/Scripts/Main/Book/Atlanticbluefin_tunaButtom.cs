using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Atlanticbluefin_tunaButtom : MonoBehaviour
{
    public GameObject BookManager;

    public GameObject GM;

    public float maxChance = 5;
    public float nowChance = 2;

    private void Start()
    {
        GM = GameObject.Find("GM");
        BookManager = GameObject.Find("BookManager");
    }

    public void Update()
    {
        if (nowChance <= maxChance)
        {
            gameObject.GetComponent<Image>().fillAmount = nowChance / maxChance;
        }
        else
        {
            gameObject.GetComponent<Image>().fillAmount = 1;
        }
    }

    public void OnToAtlanticbluefin_tuna()
    {
        BookManager.GetComponent<BookManager>().Page = 5;
    }
}
