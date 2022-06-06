using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtomGaming : MonoBehaviour
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
        if (!GM.GetComponent<GM>().isGameLoaded)
        {
            y = 1100;
        }
        if (GM.GetComponent<GM>().isGameStart && !GM.GetComponent<GM>().isGameOver && !GM.GetComponent<GM>().isPause)
        {
            if (y > 915)
            {
                y -= speed * Time.deltaTime;
                GetComponent<RectTransform>().anchoredPosition = new Vector3(-474, y, 0);
            }
        }
        if (GM.GetComponent<GM>().isGameOver || GM.GetComponent<GM>().isPause)
        {
            if (y < 1100)
            {
                y += speed * Time.deltaTime;
                GetComponent<RectTransform>().anchoredPosition = new Vector3(-474, y, 0);
            }
        }
    }
    public void OnPauseGame()
    {
        GM.GetComponent<GM>().isPause = true;
    }
}
