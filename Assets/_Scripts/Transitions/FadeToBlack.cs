using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour {

    public Camera shopCam;
    public GameObject playerCam;
    public Animator plCamFadeIn;
    public Animator shopFade;
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
            canvasGroup.alpha += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator DoFadeOut()
    {
        CanvasGroup canvasGroup = GameObject.Find("Phase Transition").GetComponent<CanvasGroup>();
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime;
            yield return null;
        }
    }

    public void EnablePlayer()
    {
        shopCam.enabled = false;
        playerCam.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        GameObject.FindGameObjectWithTag("Player").GetComponent<GunInventory>().StartGun();
        plCamFadeIn.SetBool("FadeIn", true);
        Invoke("SetFPSBool", 1);
    }

    void SetFPSBool()
    {
        plCamFadeIn.SetBool("FadeIn", false);
    }

    void SetShopBool()
    {
        shopFade.SetBool("ToShop", false);
    }

    public void ShopFade()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Destroy(GameObject.FindGameObjectWithTag("Player").GetComponent<GunInventory>().currentGun);
        Debug.Log("ShopFade");
        shopCam.enabled = true;
        playerCam.SetActive(false);
        shopFade.SetBool("ToShop", true);
        Invoke("SetShopBool", 1f);
    }

    public void EnableShop()
    {
        GamePhases.instance.gamePhases = Phases.Build;
        GamePhases.instance.PhasesGame();
    }

    public void Check()
    {
        Debug.Log("Check");
    }
}
