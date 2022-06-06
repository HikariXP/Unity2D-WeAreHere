using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishingMachine : MonoBehaviour
{
    public GameObject Centre;//用于辅助角度变换

    public GameObject JoyStick;

    public GameObject GM;

    public Rigidbody2D FMrb2;

    public GameObject ScannerUI;

    public GameObject ScannerText;

    public bool isMachineMoving = false;

    public bool isScaning;//开始收集判定

    public bool scanComplete;

    public float Scanner;//收集进度

    public float Fa = 5f;//动力加速度

    public float xspeed = 0f;

    public float yspeed = 0f;

    public float xspeedMax = 5f;

    public float yspeedMax = 5f;

    public float xfa = 2.5f;//x阻力加速度

    public float yfa = 1f;

    void Start()
    {
        Centre = GameObject.Find("Centre");
        JoyStick = GameObject.Find("JoyStick1");
        GM = GameObject.Find("GM");
        FMrb2 = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if (JoyStick.GetComponent<ScrollCircle>().onControl)
        {
            isMachineMoving = true;
        }
        else
        {
            isMachineMoving = false;
        }
        xfa = Fa / 2 * Mathf.Abs(JoyStick.GetComponent<ScrollCircle>().v.x);
        yfa = Fa / 2 * Mathf.Abs(JoyStick.GetComponent<ScrollCircle>().v.y);
        FMrb2.constraints = RigidbodyConstraints2D.FreezeRotation;
        FMrb2.velocity = new Vector2(xspeed,yspeed);
        //阻力减速
        #region
        if (xspeed > 0)
        {
            xspeed -= xfa * Time.deltaTime;
        }
        if (yspeed > 0)
        {
            yspeed -= yfa * Time.deltaTime;
        }
        if (xspeed < 0)
        {
            xspeed += xfa * Time.deltaTime;
        }
        if (yspeed < 0)
        {
            yspeed +=yfa * Time.deltaTime;
        }
        #endregion
        if (JoyStick.GetComponent<ScrollCircle>().onControl)
        {
            if (Mathf.Abs(xspeed) < xspeedMax * Mathf.Abs(JoyStick.GetComponent<ScrollCircle>().v.x))
            {
                xspeed += Fa * Time.deltaTime* JoyStick.GetComponent<ScrollCircle>().v.x;
            }
            if (Mathf.Abs(yspeed) < yspeedMax * Mathf.Abs(JoyStick.GetComponent<ScrollCircle>().v.y))
            {
                yspeed += Fa * Time.deltaTime*JoyStick.GetComponent<ScrollCircle>().v.y;
            }

            // 获取鼠标坐标并转换成世界坐标
            Vector3 m_mousePosition = new Vector3(JoyStick.GetComponent<ScrollCircle>().v.x + GetComponent<Transform>().position.x, JoyStick.GetComponent<ScrollCircle>().v.y + GetComponent<Transform>().position.y, 0f);

            m_mousePosition.z = 0;

            // 武器朝向角度
            float m_weaponAngle = Vector2.Angle(m_mousePosition - this.transform.position, Vector2.up);
            if (transform.position.x < m_mousePosition.x)
            {
                m_weaponAngle = -m_weaponAngle;
            }

            //判断武器正反
            if (m_weaponAngle > 0 && transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
            else if (m_weaponAngle < 0 && transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }

            // 变换最终角度
            transform.eulerAngles = new Vector3(0, 0, m_weaponAngle);
        }
       



    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ClownFish")
        {
            isScaning = true;
        }
        if (collision.tag == "SanWenYu")
        {
            isScaning = true;
        }
        if (collision.tag == "Shark")
        {
            isScaning = true;
        }

    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "ClownFish")
        {
            if (isScaning&&!scanComplete)
            {
                ScannerText.GetComponent<Text>().text = "Scaning";
                Scanner += Time.deltaTime * 20;
            }
            if (Scanner >= 100)
            {
                scanComplete = true;
                ScannerText.GetComponent<Text>().text = "Scan Complete";
                ScannerUI.GetComponent<UIFade>().isOK = true;
                ScannerUI.GetComponent<UIFade>().isBack = false;
                Scanner = 0;
            }
        }
        if (collision.tag == "SanWenYu")
        {
            if (isScaning && !scanComplete)
            {
                ScannerText.GetComponent<Text>().text = "Scaning";
                Scanner += Time.deltaTime * 20;
            }
            if (Scanner >= 100)
            {
                scanComplete = true;
                ScannerText.GetComponent<Text>().text = "Scan Complete";
                ScannerUI.GetComponent<UIFade>().isOK = true;
                ScannerUI.GetComponent<UIFade>().isBack = false;
                Scanner = 0;
            }
        }
        if (collision.tag == "Shark")
        {
            if (isScaning && !scanComplete)
            {
                ScannerText.GetComponent<Text>().text = "Scaning";
                Scanner += Time.deltaTime * 20;
            }
            if (Scanner >= 100)
            {
                scanComplete = true;
                ScannerText.GetComponent<Text>().text = "Scan Complete";
                ScannerUI.GetComponent<UIFade>().isOK = true;
                ScannerUI.GetComponent<UIFade>().isBack = false;
                Scanner = 0;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "ClownFish")
        {
            isScaning = false;
            if (!scanComplete)
            {
                if (Scanner >= 0)
                {
                    Scanner -= Time.deltaTime * 30;
                }
                ScannerUI.GetComponent<UIFade>().isBack = true;
                ScannerUI.GetComponent<UIFade>().isOK = false;

            }
            else
            {
                scanComplete = false;
                GM.GetComponent<GM>().fishHaveFound += 1;
                GM.GetComponent<GM>().ClownFish += 1;
            }
        }
        if (collision.tag == "Shark")
        {
            isScaning = false;
            if (!scanComplete)
            {
                if (Scanner >= 0)
                {
                    Scanner -= Time.deltaTime * 30;
                }
                ScannerUI.GetComponent<UIFade>().isBack = true;
                ScannerUI.GetComponent<UIFade>().isOK = false;

            }
            else
            {
                scanComplete = false;
                GM.GetComponent<GM>().fishHaveFound += 1;
                GM.GetComponent<GM>().Shark += 1;
            }
        }
        if (collision.tag == "Salmo_salar")
        {
            isScaning = false;
            if (!scanComplete)
            {
                if (Scanner >= 0)
                {
                    Scanner -= Time.deltaTime * 30;
                }
                ScannerUI.GetComponent<UIFade>().isBack = true;
                ScannerUI.GetComponent<UIFade>().isOK = false;

            }
            else
            {
                scanComplete = false;
                GM.GetComponent<GM>().fishHaveFound += 1;
                GM.GetComponent<GM>().Salmo_salar += 1;
            }
        }
    }
}
