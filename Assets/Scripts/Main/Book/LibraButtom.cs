using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraButtom : MonoBehaviour
{
    public GameObject BookManager;

    public GameObject GM;

    private void Start()
    {
        GM = GameObject.Find("GM");
        BookManager = GameObject.Find("BookManager");
    }

    public void OnToLibraBook()
    {
        BookManager.GetComponent<BookManager>().Page = 2;
    }
}
