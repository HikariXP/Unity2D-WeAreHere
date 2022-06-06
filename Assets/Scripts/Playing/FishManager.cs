using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishManager : MonoBehaviour
{
    //数值区
    public int seaNumber;
    public int maxFishAmount = 10;
    public int fishInSence = 0;

    public float maxX;//确定生成范围
    public float maxY;

    public float appearTime;//刷新间隔
    public float time;

    public int fishid;//需要生成的鱼的ID
    public float chanceToDeploy;

    public float x;//生成的位置
    public float y;
    public Vector3 v3;

    //物件区
    public GameObject GM;
    public GameObject Player;

    public void Start()
    { 
        GM = GameObject.Find("GM");
        Player = GameObject.Find("FishingMachine");
        seaNumber = GM.GetComponent<GM>().seaId;
    }

    public void FixedUpdate()
    {
        if (fishInSence < maxFishAmount)
        {
            if (time < appearTime)
            {
                time += Time.deltaTime;
            }
            if (time >= appearTime)
            {
                #region
                if (seaNumber == 1)
                {
                    fishid = UnityEngine.Random.Range(1, 4);
                }
                #endregion
                time = 0;

                fishid -= 1;//数组从零开始算，这个是差值运算

                //生成鱼的位置
                x = UnityEngine.Random.Range(-39,39);
                y = UnityEngine.Random.Range(-90, 75);
                if (Math.Abs(x - Player.transform.position.x) > 3)
                {
                    if (Math.Abs(y - Player.transform.position.y) > 5)
                    {
                        if (GM.GetComponent<GM>().fish[fishid].theFish != null)
                        {
                            chanceToDeploy = UnityEngine.Random.Range(0f, 1f);
                            Debug.Log("\n本次几率是" + chanceToDeploy);
                            if (chanceToDeploy <= GM.GetComponent<GM>().fish[fishid].chance)
                            {
                                v3 = new Vector3(x, y, 0);
                                Instantiate(GM.GetComponent<GM>().fish[fishid].theFish, v3, Quaternion.identity);
                                Debug.Log("已生成鱼" + fishid + "\n位置于" + x + "," + y);
                                fishInSence += 1;
                            }
                        }
                        else
                        {
                            Debug.Log("鱼类还没实装");
                        }
                    }
                }
            }
        }
    }
}
