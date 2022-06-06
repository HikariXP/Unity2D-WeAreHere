using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovePlayStart : MonoBehaviour
{
    public GameObject GM;

    public GameObject SeaBackGround;
    public Text mapName;
    public float nameAlphp = 0;
    public float Alphpa;


    public Vector3 end = new Vector3(0, 0, -10);
    public Vector3 cameraSite;
    public float Dis = 0f;
    public float speed = 0f;
    public float a = 1f;


    void Start()
    {

        GM = GameObject.Find("GM");
        GM.GetComponent<GM>().isCatchPushed = false;
        switch (GM.GetComponent<GM>().seaId)
        {
            case 1:
                mapName.GetComponent<Text>().text = GM.GetComponent<GM>().maps[0].Name; break;
            case 2:
                mapName.GetComponent<Text>().text = GM.GetComponent<GM>().maps[1].Name; break;
            case 3:
                mapName.GetComponent<Text>().text = GM.GetComponent<GM>().maps[2].Name; break;
            case 4:
                mapName.GetComponent<Text>().text = GM.GetComponent<GM>().maps[3].Name; break;
        }
        StartCoroutine("PrintMapName");
        if (!GM.GetComponent<GM>().isGameLoaded)
        {
            transform.position = new Vector3(0, 15, -10);
            cameraSite = GetComponent<Camera>().GetComponent<Transform>().position;
            GM.GetComponent<GM>().isGameLoaded = true;
        }
    }
    IEnumerator PrintMapName()
    {
        mapName.GetComponent<Text>().color =new Color(1,1,1,0);
        OnGUI();
        yield return new WaitForSeconds(1.5f);
        Alphpa = -Alphpa;
        OnGUI();
    }

    void FixedUpdate()
    {
        if (GM.GetComponent<GM>().isGameLoaded&&!GM.GetComponent<GM>().isGameStart)
        {
            if (Dis < 7.5)
            {
                speed += a * Time.deltaTime;
            }
            if (Dis > 7.5)
            {
                speed -= a * Time.deltaTime;
            }
            Dis += speed*Time.deltaTime;
            transform.position = Vector3.MoveTowards(cameraSite, end, Dis);
            if (Dis > 14.88)
            {
                GM.GetComponent<GM>().isGameStart = true;
                GM.GetComponent<GM>().isGameMoveToRightWay = true;
            }
        }
    }
    public void OnGUI()
    {
            nameAlphp += Alphpa * Time.deltaTime;
            mapName.GetComponent<Text>().color = new Color(1, 1, 1, nameAlphp);
    }
}
