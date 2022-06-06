using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelNameMove : MonoBehaviour
{
    public GameObject GM;

    public float y;

    public float speed = 800f;

    public void Start()
    {
        GM = GameObject.Find("GM");
        y = GetComponent<RectTransform>().anchoredPosition.y;
    }

    public void FixedUpdate()
    {
        if (!GM.GetComponent<GM>().isMainMoveToRightWay)
        {
            y = 1100;
        }
        if (GM.GetComponent<GM>().isMainLoaded && !GM.GetComponent<GM>().isMainStart && !GM.GetComponent<GM>().isbusy)
        {
            if (y > 935)
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
    public void OnSelectLevel()
    {
        GM.GetComponent<GM>().isSelectLevel = true;
        GM.GetComponent<GM>().isbusy = true;
    }
}
