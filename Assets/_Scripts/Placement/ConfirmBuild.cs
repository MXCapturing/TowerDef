using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmBuild : MonoBehaviour {

    private GamePhases phases;
    public Animator fadeIn;

    private void Start()
    {
        phases = GameObject.Find("GameManager").GetComponent<GamePhases>();
    }

    public void Confirm()
    {
        for (int i = 0; i < ShopMenu.instance.subMenus.Length; i++)
        {
            ShopMenu.instance.subMenus[i].SetActive(false);
        }
        fadeIn.SetBool("FadeOut", true);
        Invoke("SetBool", 1);
        phases.gamePhases = Phases.FPS;
        GameObject.FindGameObjectWithTag("GameController").GetComponent<EnemyWaves>().state = EnemyWaves.SpawnState.Counting;
        phases.PhasesGame();
    }

    private void SetBool()
    {
        fadeIn.SetBool("FadeOut", false);
    }
}
