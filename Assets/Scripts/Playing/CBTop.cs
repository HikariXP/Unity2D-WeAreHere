using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CBTop : MonoBehaviour
{
    //物件区
    public GameObject GM;


    //数值区
    public float Confirmtime = 0;

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
    void Update()
    {
        if (Confirmtime >= 3)
        {
            GM.GetComponent<GM>().isConfirmGameOver = false;
            Confirmtime = 0;
        }
    }

    public void FixedUpdate()
    {
        if (GM.GetComponent<GM>().isGameMoveToRightWay && !GM.GetComponent<GM>().isPause)
        {
            if (x > 440)
            {
                x -= Time.deltaTime * 800;
                gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
            }
        }
        if (GM.GetComponent<GM>().isGameOver || GM.GetComponent<GM>().isPause)
        {
            if (x < 800)
            {
                x += Time.deltaTime * 800;
                gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
            }
        }
        if (GM.GetComponent<GM>().isConfirmGameOver)
        {
            if (y > -140)
            {
                y -= Time.deltaTime * 800;
                gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
            }
            Confirmtime += Time.deltaTime;
        }
        else
        {
            if (y < 0)
            {
                y += Time.deltaTime * 800;
                gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
            }
            if (y > 0)
            {
                y = 0;
                gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
            }
        }
    }

    public void OnConfirmGameOver()
    {
        GM.GetComponent<GM>().isConfirmGameOver = true;
    }
}
