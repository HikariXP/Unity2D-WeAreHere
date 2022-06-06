using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CBbuttom : MonoBehaviour
{
    public float bt = 0;

    public GameObject GM;

    public GameObject BackUI;

    public GameObject Black;

    public bool blackOK = false;

    public void OnComfirmBackGame()
    {
        GM = GameObject.Find("GM");
        StartCoroutine("BackWay");
    }

    IEnumerator BackWay()
    {
        BackUI.GetComponent<UIFade>().isOK = true;
        GM.GetComponent<GM>().isGameOver = true;
        yield return new WaitForSeconds(2);
        Black.SetActive(true);
        blackOK = true;
        yield return new WaitForSeconds(4);
        blackOK = false;
        GM.GetComponent<GM>().skyNumber = UnityEngine.Random.Range(1, 5);
        GM.GetComponent<GM>().isGameOver = false;
        GM.GetComponent<GM>().SaveGame();
        Application.LoadLevel("Main");
    }

    public void Update()
    {
        if (blackOK)
        {
            Black.GetComponent<Image>().color = new Color(0, 0, 0, bt += Time.deltaTime * 0.7f);
        }
    }
        
}
