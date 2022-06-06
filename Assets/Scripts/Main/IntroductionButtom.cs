using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroductionButtom : MonoBehaviour
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
            if (y > 915)
            {
                y -= speed * Time.deltaTime;
                GetComponent<RectTransform>().anchoredPosition = new Vector3(474, y, 0);
            }
        }
        if (GM.GetComponent<GM>().isMainStart || GM.GetComponent<GM>().isbusy)
        {
            if (y < 1100)
            {
                y += speed * Time.deltaTime;
                GetComponent<RectTransform>().anchoredPosition = new Vector3(474, y, 0);
            }
        }
    }
    public void OnIntroducing()
    {
        GM.GetComponent<GM>().isIntroducing = true;
        GM.GetComponent<GM>().isbusy = true;
    }
}
