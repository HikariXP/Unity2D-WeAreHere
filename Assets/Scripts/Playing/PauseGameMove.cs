using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameMove : MonoBehaviour
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
        if (GM.GetComponent<GM>().isGameLoaded && GM.GetComponent<GM>().isGameStart && GM.GetComponent<GM>().isPause)
        {
            if (y >= 0)
            {
                y -= speed * Time.deltaTime;
                GetComponent<RectTransform>().anchoredPosition = new Vector3(0, y, 0);
            }
        }
        if (GM.GetComponent<GM>().isGameOver || !GM.GetComponent<GM>().isPause)
        {
            if (y < 2000)
            {
                y += speed * Time.deltaTime;
                GetComponent<RectTransform>().anchoredPosition = new Vector3(0, y, 0);
            }
        }

    }
}
