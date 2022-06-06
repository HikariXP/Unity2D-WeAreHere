using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SharkBook : MonoBehaviour
{
    public GameObject GM;

    public GameObject Sharkfill;

    public float canSee;

    public string TextA = "\t鲨鱼早在恐龙出现前三亿年前就已经存在地球上，至今已超过五亿年，它们在近一亿年来几乎没有改变。";    //简介
    public string TextB = "传统观念认为鲨鱼的软骨（即鱼翅）中蛋白质很高，但这是错误的。鸡蛋的蛋白质远远超过鱼翅。";    //常见
    public string TextC = "鲨鱼大多以鱼等海洋动物为食。鲨鱼以受伤的海洋哺乳类、鱼类和腐肉为生，剔除动物中较弱的成员。鲨鱼也会吃船上抛下的垃圾和其它废弃物。此外，有些鲨鱼也会猎食各种海洋哺乳类、鱼类和海龟和螃蟹等动物。有些鲨鱼能几个月不进食，大白鲨就是其中一种。据报道，大白鲨要隔一、两个月才进食一次。";    //生活习性
    public string TextD = "由于人类大量猎杀，现存极少，CR级濒危";    //濒危程度
    public string temp = "!!!资料缺失，请搜寻该鱼类以补全资料!!!";


    void Start()
    {
        GM = GameObject.Find("GM");
        Sharkfill = GameObject.Find("SharkBook");
        canSee = Sharkfill.GetComponent<Atlanticbluefin_tunaButtom>().nowChance / Sharkfill.GetComponent<Atlanticbluefin_tunaButtom>().maxChance;
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
