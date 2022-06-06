using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookManager : MonoBehaviour
{
    //页码显示内容控制
    //天枰洋海域鱼类图鉴
    public GameObject ClownFish;//第2页按钮
    public GameObject Salmo_salar;//第3页按钮
    public GameObject Shark;//第4页按钮
    public GameObject Atlanticbluefin_tuna;//第5页按钮

    public GameObject ClownFishBook;//第2页
    public GameObject Salmo_salarBook;//第3页
    public GameObject SharkBook;//第4页
    public GameObject Atlanticbluefin_tunaBook;//第5页

    public GameObject GM;

    public int Page = 1;

    void Start()
    {
        GM = GameObject.Find("GM");
    }

    void Update()
    {
        if (Page != 1)
        {
            ClownFish.SetActive(false);
            Salmo_salar.SetActive(false);
            Shark.SetActive(false);
            Atlanticbluefin_tuna.SetActive(false);
        }
        if (Page == 1)
        {
            ClownFish.SetActive(true);
            Salmo_salar.SetActive(true);
            Shark.SetActive(true);
            Atlanticbluefin_tuna.SetActive(true);
        }
        //小丑鱼
        #region
        if (Page == 2)
        {
            ClownFishBook.SetActive(true);
            ClownFishBook.GetComponent<UIFade>().isOK = true;
            ClownFishBook.GetComponent<UIFade>().isBack = false;
        }
        else
        {
            ClownFishBook.GetComponent<UIFade>().isOK = false;
            ClownFishBook.GetComponent<UIFade>().isBack = true;
            ClownFishBook.SetActive(false);
        }
        #endregion
        if (Page == 3)
        {
            Salmo_salarBook.SetActive(true);
            Salmo_salarBook.GetComponent<UIFade>().isOK = true;
            Salmo_salarBook.GetComponent<UIFade>().isBack = false;
        }
        else
        {
            Salmo_salarBook.GetComponent<UIFade>().isOK = false;
            Salmo_salarBook.GetComponent<UIFade>().isBack = true;
            Salmo_salarBook.SetActive(false);
        }
        if (Page == 4)
        {
            SharkBook.SetActive(true);
            SharkBook.GetComponent<UIFade>().isOK = true;
            SharkBook.GetComponent<UIFade>().isBack = false;
        }
        else
        {
            SharkBook.GetComponent<UIFade>().isOK = false;
            SharkBook.GetComponent<UIFade>().isBack = true;
            SharkBook.SetActive(false);
        }
        //蓝鳍金枪鱼
        #region
        if (Page == 5)
        {
            Atlanticbluefin_tunaBook.SetActive(true);
            Atlanticbluefin_tunaBook.GetComponent<UIFade>().isOK = true;
            Atlanticbluefin_tunaBook.GetComponent<UIFade>().isBack = false;
        }
        else
        {
            Atlanticbluefin_tunaBook.GetComponent<UIFade>().isOK = false;
            Atlanticbluefin_tunaBook.GetComponent<UIFade>().isBack = true;
            Atlanticbluefin_tunaBook.SetActive(false);
        }
        #endregion
    }
}
