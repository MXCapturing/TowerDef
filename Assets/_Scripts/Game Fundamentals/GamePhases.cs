using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Phases
{
    Build,
    FPS
}

public class GamePhases : MonoBehaviour {

    public static GamePhases instance;

    public Phases gamePhases;

    public GameObject shopMenu;

    public AudioSource musicPlayer;
    public AudioClip shopMusic;
    public AudioClip fpsMusic;

	// Use this for initialization
	void Start () {
        instance = this;
        PhasesGame();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PhasesGame()
    {
        switch (gamePhases)
        {
            case Phases.Build:
                shopMenu.SetActive(true);
                musicPlayer.clip = shopMusic;
                musicPlayer.Play();
                break;

            case Phases.FPS:
                shopMenu.SetActive(false);
                musicPlayer.clip = fpsMusic;
                musicPlayer.Play();
                break;
        }
    }
}
