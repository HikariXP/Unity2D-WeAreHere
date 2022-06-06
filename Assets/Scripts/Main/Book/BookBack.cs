using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookBack : MonoBehaviour
{
    public GameObject GM;

    public GameObject BookManager;

    public void Start()
    {
        GM = GameObject.Find("GM");
        BookManager = GameObject.Find("BookManager");
    }

    public void onBackToMain()
    {
        if (BookManager.GetComponent<BookManager>().Page == 1)
        {
            GM.GetComponent<GM>().isBookIng = false;
            GM.GetComponent<GM>().isbusy = false;
        }
        else
        {
            BookManager.GetComponent<BookManager>().Page = 1;
        }
    }

}
