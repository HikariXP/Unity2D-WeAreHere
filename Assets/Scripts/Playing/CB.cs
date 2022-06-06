using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CB : MonoBehaviour
{
    //物件区
    public GameObject GM;


    //数值区

    public float x;
    public float y;

    public float speed = 800;

    public float a = 0;

    void Start()
    {
        GM = GameObject.Find("GM");
        y = gameObject.GetComponent<RectTransform>().anchoredPosition.y;
        x = gameObject.GetComponent<RectTransform>().anchoredPosition.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GM.GetComponent<GM>().isGameMoveToRightWay&&!GM.GetComponent<GM>().isPause)
        {
            if (x > 440)
            {
                x -= Time.deltaTime * 800;
                gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
            }
        }
        if (GM.GetComponent<GM>().isGameOver||GM.GetComponent<GM>().isPause)
        {
            if (x < 800)
            {
                x += Time.deltaTime * 800;
                gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
            }
        }
    }
}