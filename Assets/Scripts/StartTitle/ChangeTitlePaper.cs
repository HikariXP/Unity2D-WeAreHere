using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTitlePaper : MonoBehaviour
{
    public GameObject GM;

    public GameObject Camera;

    public Texture2D image1;

    public Texture2D image2;

    public Texture2D image3;

    public int imageNumber = 1;

    void Start()
    {
        GM = GameObject.Find("GM");
        StartCoroutine("ChangeTitle");
    }

    IEnumerator ChangeTitle()
    {
        yield return new WaitForSeconds(2.5f);
        imageNumber = 2;
        yield return new WaitForSeconds(0.15f);
        imageNumber = 1;
        yield return new WaitForSeconds(0.7f);
        imageNumber = 3;
        yield return new WaitForSeconds(0.1f);
        imageNumber = 1;
        yield return new WaitForSeconds(2.5f);
    }

    void Update()
    {
        //if(imageNumber == 1)
        //{
        //    Camera.GetComponent<AcrylicLogo>().SplashLogo = image1;
        //}
        //if (imageNumber == 2)
        //{
        //    Camera.GetComponent<AcrylicLogo>().SplashLogo = image2;
        //}
        //if (imageNumber == 3)
        //{
        //    Camera.GetComponent<AcrylicLogo>().SplashLogo = image3;
        //}
    }
}
