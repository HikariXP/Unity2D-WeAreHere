using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Atlanticbluefin_tunaText : MonoBehaviour
{
    public GameObject GM;

    public GameObject Atlanticbluefin_tunafill;

    public float canSee;

    public string TextA = "\t蓝鳍金枪?，为硬骨%纲辐鳍鱼亚#$%目鲭亚目鲭科的其中一种，广泛分@$&半球的太平洋和大西洋海域中";    //简介
    public string TextB = "%&|欧盟~#%保护法^#$未通%@^&*!经济产@#$%^&*\t\t警告，该鱼类信息极其残缺，请尽快搜索        --最后更新于2019.4.1";    //常见
    public string TextC = "";    //生活习性
    public string TextD = "";    //濒危程度
    public string temp = "!!!资料缺失，请搜寻该鱼类以补全资料!!!";


    void Start()
    {
        GM = GameObject.Find("GM");
        Atlanticbluefin_tunafill = GameObject.Find("Atlanticbluefin_tunaButtom");
        canSee = Atlanticbluefin_tunafill.GetComponent<Atlanticbluefin_tunaButtom>().nowChance / Atlanticbluefin_tunafill.GetComponent<Atlanticbluefin_tunaButtom>().maxChance;
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
