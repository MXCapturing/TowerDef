using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavmeshTarget : MonoBehaviour {

    public NavMeshAgent agent;
    private GamePhases phases;

    public bool trapped;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        phases = GameObject.Find("GameManager").GetComponent<GamePhases>();
	}
	
	// Update is called once per frame
	void Update () {
        if(phases.gamePhases == Phases.FPS && trapped == false)
        {
            agent.speed = 3.5f;
        }
        if(phases.gamePhases == Phases.Build || trapped == true)
        {
            agent.speed = 0;
        }
	}
}
