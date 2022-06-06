using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//        GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 1);
//UI移动代码

public class StartButtom : MonoBehaviour
{
    public GameObject GM;

    public Vector3 moveToHere;//动作结束后的位置

    public Vector3 theStartPos;//一开始的位置

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
            y = -1100;
        }
        if (GM.GetComponent<GM>().isMainLoaded&&!GM.GetComponent<GM>().isMainStart&&!GM.GetComponent<GM>().isbusy)
        {
            if (y < -870)
            {
                y += speed * Time.deltaTime;
                GetComponent<RectTransform>().anchoredPosition = new Vector3(0, y, 0);
            }
        }
        if (GM.GetComponent<GM>().isMainStart||GM.GetComponent<GM>().isbusy)
        {
            if (y > -1100)
            {
                y -= speed * Time.deltaTime;
                GetComponent<RectTransform>().anchoredPosition = new Vector3(0, y, 0);
            }
        }
    }

    public void OnStartTheGame()
    {
        GM.GetComponent<GM>().isMainStart = true;
        y = GetComponent<RectTransform>().anchoredPosition.y;
        GM.GetComponent<GM>().launchTime += 1;
    }
}
