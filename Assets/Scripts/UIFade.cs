using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : MonoBehaviour
{
    public GameObject TEXT;

    public Color color;

    public bool isOK = false;

    public float FTime = 0f;

    public float xend = 0f;

    public float yend = 0f;

    public float xa = 0f;

    public float ya = 0f;

    public float ta = 0f;

    public float x = 0f;

    public float y = 5f;

    public float t = 0f;

    public float imageT;

    public bool needToDisapear = false;

    public bool needToBack = false;

    public bool isBack = false;

    public void Start()
    {
        isOK = false;
        color = TEXT.GetComponent<Text>().color;
        imageT = this.GetComponent<Image>().color.a;
        xa = xend / FTime;
        ya = yend / FTime;
    }

    public void Update()
    {
        if (isOK)
        {
            if (x < xend)
            {
                x += xa*Time.deltaTime;
            }
            if (x >= xend)
            {
                if(y<yend)
                {
                    y += ya * Time.deltaTime;
                }

            }
            GetComponent<RectTransform>().sizeDelta = new Vector2(x, y);
            if (y >= yend&&t<1)
            {
                t += ta * Time.deltaTime;
                TEXT.GetComponent<Text>().color = new Color(color.r, color.g, color.b, t);
            }
        }
        if (needToBack)
        {
            if (isBack)
            {
                if (t > 0)
                {
                    t -= ta * Time.deltaTime;
                }
                isOK = false;
                if (x > 0)
                {
                    x -= xa * Time.deltaTime;

                }
                if (x <= 0)
                {
                    if (y > 0)
                    {
                        y -= ya * Time.deltaTime;
                    }
                }
                if (t <= 0)
                {
                    isBack = false;
                }
                TEXT.GetComponent<Text>().color = new Color(color.r, color.g, color.b, t);
                GetComponent<RectTransform>().sizeDelta = new Vector2(x, y);
            }
        }
        if (needToDisapear)
        {
            if (t >= 1)
            {
                StartCoroutine("UIfADE");
                isOK = false;
            }
        }

    }
    IEnumerator UIfADE()
    {
        yield return new WaitForSeconds(1);
        Uitextfade();
        Uiimagefade();
    }

    public void Uitextfade()
    {
        TEXT.GetComponent<Text>().color = new Color(color.r, color.g,color.b, color.a);
    }

    public void Uiimagefade()
    {
        imageT -= 1.5f*ta * Time.deltaTime;
        GetComponent < Image> ().color = new Color(this.GetComponent < Image > ().color.r, this.GetComponent < Image > ().color.g, this.GetComponent < Image > ().color.b, imageT);
    }

}
