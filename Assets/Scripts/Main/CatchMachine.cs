using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatchMachine : MonoBehaviour
{
    public GameObject GM;
    public GameObject FishingM;
    public GameObject Catch;
    public Sprite CatchG;
    public Sprite CatchR;

    void Start()
    {
        GM = GameObject.Find("GM");
        Catch.GetComponent<SpriteRenderer>().sprite = CatchR;
    }


    void Update()
    {
        if (GM.GetComponent<GM>().isMainStart)
        {
            StartCoroutine("CatchM");
        }
    }
    IEnumerator CatchM()
    {
        yield return new WaitForSeconds(1);
        Catch.GetComponent<SpriteRenderer>().sprite = CatchG;
        yield return new WaitForSeconds(1);
        FishingM.GetComponent<Rigidbody2D>().gravityScale = 1;
        GM.GetComponent<GM>().isCatchPushed = true;
        yield return new WaitForSeconds(2);
    }
}
