using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveMain : MonoBehaviour
{
    public GameObject GM;
    public Vector3 cameraSite;
    public Vector3 MainWay = new Vector3(0, 2, -10);
    public Vector3 end = new Vector3(0, -8, -10);
    public float Dis = 0f;
    public float speed = 0f;
    public float a = 2f;

    void Start()
    {
        transform.position = new Vector3(0, -10, -10);
        GM = GameObject.Find("GM");
        cameraSite = GetComponent<Camera>().GetComponent<Transform>().position;
    }
    void FixedUpdate()
    {
        if (!GM.GetComponent<GM>().isMainMoveToRightWay && !GM.GetComponent<GM>().isGameOver)
        {
            GetComponent<Transform>().position = new Vector3(0, -10, -10);
            GM.GetComponent<GM>().isMainMoveToRightWay = true;
            GM.GetComponent<GM>().isGameMoveToRightWay = false;
            GM.GetComponent<GM>().isGameLoaded = false;
            GM.GetComponent<GM>().isGameStart = false;
        }
            if (!GM.GetComponent<GM>().isMainLoaded)
        {
            speed += a * Time.deltaTime;
            Dis += speed * Time.deltaTime;
            if (Dis >= 6)
            {
                a = -1.95f;
            }
            transform.position = Vector3.MoveTowards(cameraSite, MainWay, Dis);
            if (Dis >= 12)
            {
                cameraSite = GetComponent<Camera>().GetComponent<Transform>().position;
                GM.GetComponent<GM>().isMainLoaded = true;
                speed = 0f;
                Dis = 0;
                a = 2f;
            }
        }
        if (GM.GetComponent<GM>().isCatchPushed)
        {
            speed += a * Time.deltaTime;
            Dis += speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(cameraSite, end, Dis);
        }
        if (Dis >=25)
        {
            GM.GetComponent<GM>().isMainLoaded = false;
            GM.GetComponent<GM>().isMainStart = false;
            GM.GetComponent<GM>().isMainMoveToRightWay = false;
            Application.LoadLevel("Playing");
        }
    }
}
