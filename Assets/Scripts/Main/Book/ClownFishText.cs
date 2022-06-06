using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClownFishText : MonoBehaviour
{
    public GameObject GM;

    public GameObject ClownFishFill;

    public float canSee;

    public string TextA = "\t小丑鱼是对雀鲷科海葵鱼亚科鱼类的俗称，因为脸上都有一条或两条白色条纹，好似京剧中的丑角而得名，是一种热带咸水鱼。";    //简介
    public string TextB = "\t稚鱼全体黑色的有鳞片集中蓝色的；在前额与上侧面上的白色的斑块；所有的鳍黑色除透明的胸鳍与软背鳍鳍条的外部部分。成鱼的地理而行为颜色可变的。";    //常见
    public string TextC = "\t生物学特性：栖息于珊瑚礁与岩礁，稚鱼时常与大的海葵，海胆或小的珊瑚顶部共生。形成小群到大群鱼群，胃内含物包括藻类，桡脚类的动物与其他的浮游性甲壳动物。";    //生活习性
    public string TextD = "\t由于海水污染导致珊瑚类急剧减少，严重威胁了小丑鱼的生存，现已进入濒危保护行列      --最后更新2069.3.6";    //濒危程度
    public string temp = "!!!资料缺失，请搜寻该鱼类以补全资料!!!";


    void Start()
    {
        GM = GameObject.Find("GM");
        ClownFishFill = GameObject.Find("ClownFishButtom");
        canSee = ClownFishFill.GetComponent<ClownFishButtom>().nowChance / ClownFishFill.GetComponent<ClownFishButtom>().maxChance;
    }

    void Update()
    {
        if (canSee >= 1)
        {
            GetComponent<Text>().text = TextA + "\n"+ TextB + "\n" + TextC + "\n" + TextD;
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
            GetComponent<Text>().text =  temp;
        }
    }
}
