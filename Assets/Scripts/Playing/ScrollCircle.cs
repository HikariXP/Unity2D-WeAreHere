using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
  
  public class ScrollCircle : ScrollRect
  {
    //y值用于使摇杆位置动态变换
    public float y;
    public float speed = 1000;

    public GameObject GM;
    //判断是否按下
    public bool onControl = false;
    //输出摇杆数据
    public Vector2 v;
    //摇杆底部的动态变化
    public float BackGround;


      // 半径
    private float _mRadius = 0f;
 
     // 距离
    private const float Dis = 0.5f;
 
     protected override void Start()
     {
         base.Start();
        y =  GetComponent<RectTransform>().anchoredPosition.y;
        GM = GameObject.Find("GM");
        BackGround = GetComponent<RectTransform>().sizeDelta.x;
         // 能移动的半径 = 摇杆的宽 * Dis
         _mRadius = content.sizeDelta.x* Dis;
     }
 
     public override void OnDrag(PointerEventData eventData)
     {
         base.OnDrag(eventData);
         onControl = true;   
         // 获取摇杆，根据锚点的位置。
         var contentPosition = content.anchoredPosition;
 
         // 判断摇杆的位置 是否大于 半径
         if (contentPosition.magnitude > _mRadius)
         {   
             // 设置摇杆最远的位置
             contentPosition = contentPosition.normalized* _mRadius;
             SetContentAnchoredPosition(contentPosition);
         }
 
         // 最后 v2.x/y 就跟 Input中的 Horizontal Vertical 获取的值一样 
         var v2 = content.anchoredPosition.normalized;
        v = v2;
     }
    public override void OnEndDrag(PointerEventData eventData)//松手
    {
        base.OnEndDrag(eventData);
        onControl = false;
    }
    public void FixedUpdate()
    {
        ScrollCirclePrint();
        ScrollCircleAppear();
    }
    //摇杆背景动态变化的类
    #region
    public void ScrollCirclePrint()
    {
        if (onControl)
        {
            if (BackGround <= 300)
            {
                BackGround += 1000 * Time.deltaTime;
                GetComponent<RectTransform>().sizeDelta = new Vector2(BackGround, BackGround);
            }
        }
        if (!onControl)
        {
            if (BackGround >= 150)
            {
                BackGround -= 1000 * Time.deltaTime;
                GetComponent<RectTransform>().sizeDelta = new Vector2(BackGround, BackGround);
            }
        }
    }
    #endregion
    public void ScrollCircleAppear()
    {
        if (GM.GetComponent<GM>().isGameStart&&!GM.GetComponent<GM>().isGameOver&&!GM.GetComponent<GM>().isPause)
        {
             if (y < -700)
             {
                    y += speed * Time.deltaTime;
                    GetComponent<RectTransform>().anchoredPosition = new Vector3(0, y, 0);
             }
        }
        if (GM.GetComponent<GM>().isGameOver|| GM.GetComponent<GM>().isPause)
        {
            if (y>-1100)
            {
                y -= speed * Time.deltaTime;
                GetComponent<RectTransform>().anchoredPosition = new Vector3(0, y, 0);
            }

        }
    }
}