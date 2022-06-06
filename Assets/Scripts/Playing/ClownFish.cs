using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownFish : MonoBehaviour
{
    //判断区
    public bool isMaster = false;   //判断是否领航
    public bool hasLeader = false;

    public bool isAffraid;

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


    

    void Awake()
    {
        x = gameObject.transform.position.x;
        y = gameObject.transform.position.y;
        Player = GameObject.Find("FishingMachine");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.gameObject.tag == "Player")
            {
                isAffraid = true;
            }
            else if (collision.gameObject.tag == "ClownFish")//用于判断
            {
                if (!hasLeader)
                    Number = Random.Range(0, 10);
                if (collision.gameObject.GetComponent<ClownFish>().Number > Number)
                {
                    collision.gameObject.GetComponent<ClownFish>().isMaster = true;
                    hasLeader = true;
                }
            }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isAffraid = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (isAffraid)
        {
            AffraidToMove();
        }
        else
        {
            if (!hasLeader)
            {
                if (!haveTarget)
                {
                    xend = UnityEngine.Random.Range(-39, 39);
                    yend = UnityEngine.Random.Range(-90, -20);
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
    }

    void AffraidToMove()
    {

    }
}
