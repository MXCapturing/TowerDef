using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour {

    public Camera shopCam;
    public GameObject playerCam;
    public Animator plCamFadeIn;
    public bool inOrOut = false;

    public void FadeMe()
    {
        inOrOut = !inOrOut;

        if(inOrOut == true)
        {
            StartCoroutine(DoFadeIn());
        }
        if(inOrOut == false)
        {
            StartCoroutine(DoFadeOut());
        }
    }

    IEnumerator DoFadeIn()
    {
        CanvasGroup canvasGroup = GameObject.Find("Phase Transition").GetComponent<CanvasGroup>();
        while(canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime / 2;
            yield return null;
        }
    }

    IEnumerator DoFadeOut()
    {
        CanvasGroup canvasGroup = GameObject.Find("Phase Transition").GetComponent<CanvasGroup>();
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime / 2;
            yield return null;
        }
    }

    public void EnableShop()
    {
        shopCam.enabled = true;
        playerCam.SetActive(false);
    }

    public void EnablePlayer()
    {
        shopCam.enabled = false;
        playerCam.SetActive(true);
        plCamFadeIn.SetBool("FadeIn", true);
        Invoke("SetBool", 1);
    }

    void SetBool()
    {
        plCamFadeIn.SetBool("FadeIn", false);
    }
}
