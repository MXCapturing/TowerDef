using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavmeshTarget : MonoBehaviour {

    public Transform target;
    private NavMeshAgent agent;
    private GamePhases phases;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.position);
        phases = GameObject.Find("GameManager").GetComponent<GamePhases>();
	}
	
	// Update is called once per frame
	void Update () {
        if(phases.gamePhases == Phases.FPS)
        {
            agent.speed = 3.5f;
        }
        if(phases.gamePhases == Phases.Build)
        {
            agent.speed = 0;
        }
	}
}
