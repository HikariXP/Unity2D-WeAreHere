using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookButtom : MonoBehaviour
{
    public GameObject GM;

    public float bt = 0;

    public float y;

    public float speed = 800f;

    public GameObject Black;

    public bool blackOK = false;

    public void Start()
    {
        GM = GameObject.Find("GM");
        y = GetComponent<RectTransform>().anchoredPosition.y;
    }

    public void FixedUpdate()
    {
        if (GM.GetComponent<GM>().isMainLoaded && !GM.GetComponent<GM>().isMainStart && !GM.GetComponent<GM>().isbusy)
        {
            if (y > 915)
            {
                y -= speed * Time.deltaTime;
                GetComponent<RectTransform>().anchoredPosition = new Vector3(0, y, 0);
            }
        }
        if (GM.GetComponent<GM>().isMainStart || GM.GetComponent<GM>().isbusy)
        {
            if (y < 1100)
            {
                y += speed * Time.deltaTime;
                GetComponent<RectTransform>().anchoredPosition = new Vector3(0, y, 0);
            }
        }
    }
    public void OnOpenBook()
    {
        GM.GetComponent<GM>().isBookIng = true;
        GM.GetComponent<GM>().isbusy = true;
    }

}
