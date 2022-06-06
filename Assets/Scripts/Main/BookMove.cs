using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookMove : MonoBehaviour
{
    public GameObject GM;

    public float y;

    public float speed = 2000f;

    public void Start()
    {
        GM = GameObject.Find("GM");
        y = GetComponent<RectTransform>().anchoredPosition.y;
    }

    public void FixedUpdate()
    {
        if (!GM.GetComponent<GM>().isMainMoveToRightWay)
        {
            y = 2000;
        }
        if (GM.GetComponent<GM>().isMainLoaded && !GM.GetComponent<GM>().isMainStart && GM.GetComponent<GM>().isBookIng)
        {
            if (y > 0)
            {
                y -= speed * Time.deltaTime;
                GetComponent<RectTransform>().anchoredPosition = new Vector3(0, y, 0);
            }
        }
        if (GM.GetComponent<GM>().isMainStart || !GM.GetComponent<GM>().isBookIng)
        {
            if (y < 2000)
            {
                y += speed * Time.deltaTime;
                GetComponent<RectTransform>().anchoredPosition = new Vector3(0, y, 0);
            }
        }
    }
}
