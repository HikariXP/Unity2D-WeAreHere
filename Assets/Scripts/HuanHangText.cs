using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HuanHangText : MonoBehaviour
{

    Text myText;

    void Start()
    {
        myText = GetComponent<Text>();
        myText.text = myText.text.Replace("\\n", "\n");
    }
}
