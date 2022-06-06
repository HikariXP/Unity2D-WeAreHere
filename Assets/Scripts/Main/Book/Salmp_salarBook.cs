using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Salmp_salarBook : MonoBehaviour
{
    public GameObject GM;

    public GameObject Salmo_salarfill;

    public float canSee;

    public string TextA = "\t三文鱼是部分鲑科鱼类的俗称，原本指的是鲑属的大西洋鲑鱼（Salmo salar)";    //简介
    public string TextB = "三文鱼具有商业价值的品种有30多个，目前最常见的是2种鳟鱼（三文鳟、金鳟）和4种鲑鱼（太平洋鲑、大西洋鲑、北极白点鲑、银鲑）";    //常见
    public string TextC = "三文鱼为溯河洄游性鱼类，在河溪中生活1～5年后，再入海生活2～4年。产卵期为8月至翌年1月。溯河产卵洄游期间，它们跳越小瀑布和小堤坝，经过长途跋涉，千辛万苦才能到达产卵场，而且还不摄食。";    //生活习性
    public string TextD = "有大量人工养殖以及转基因改造，并不濒危";    //濒危程度
    public string temp = "!!!资料缺失，请搜寻该鱼类以补全资料!!!";


    void Start()
    {
        GM = GameObject.Find("GM");
        Salmo_salarfill = GameObject.Find("Salmo_salarBook");
        canSee = Salmo_salarfill.GetComponent<Atlanticbluefin_tunaButtom>().nowChance / Salmo_salarfill.GetComponent<Atlanticbluefin_tunaButtom>().maxChance;
    }

    void Update()
    {
        if (canSee >= 1)
        {
            GetComponent<Text>().text = TextA + "\n" + TextB + "\n" + TextC + "\n" + TextD;
        }
        else if (canSee >= 0.75)
        {
            GetComponent<Text>().text = TextA + "\n" + TextB + "\n" + TextC + "\n" + temp;
        }
        else if (canSee >= 0.5)
        {
            GetComponent<Text>().text = TextA + "\n" + TextB + "\n" + temp;
        }
        else if (canSee >= 0.25)
        {
            GetComponent<Text>().text = TextA + "\n" + temp;
        }
        else if (canSee >= 0)
        {
            GetComponent<Text>().text = temp;
        }
    }
}
