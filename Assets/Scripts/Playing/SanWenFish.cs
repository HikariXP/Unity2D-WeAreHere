using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanWenFish : MonoBehaviour
{
    //判断区
    public bool haveTarget;
    public bool TargetDone;

    //数值区
    public float xspeed = 1f;
    public float yspeed = 1f;



    public int Number = 0;//用于比大小，判断谁做Leader

    public float xend;//用以巡逻定位，逻辑跟FishManager随机生成位置一样
    public float yend;
    public float x;
    public float y;

    //物品区
    public GameObject Player;


    

    public void Awake()
    {
        x = gameObject.transform.position.x;
        y = gameObject.transform.position.y;
        Player = GameObject.Find("FishingMachine");
    }


    // Update is called once per frame
    void Update()
    {


                if (!haveTarget)
                {
                    xend = UnityEngine.Random.Range(-39, 39);
                    yend = UnityEngine.Random.Range(-20, 70);
                    haveTarget = true;
                    TargetDone = false;
                }
                #region
                if (x > xend)
                {
                    xspeed = -2.5f;
                }
                else
                {
                    xspeed = 2.5f;
                }
                if (y > yend)
                {
                    yspeed = -2.5f;
                }
                else
                {
                    yspeed = 2.5f;
                }
                #endregion
                transform.position = new Vector2(x+xspeed*Time.deltaTime,y+yspeed*Time.deltaTime);
                x = gameObject.transform.position.x;
                y = gameObject.transform.position.y;
                if (Mathf.Abs(x - xend) < 2&& Mathf.Abs(y - yend) < 2)
                {
                    TargetDone = true;
                    haveTarget = false;
                }
            }
        }
    


