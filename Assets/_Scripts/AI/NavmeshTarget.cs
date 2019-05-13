﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavmeshTarget : MonoBehaviour {

    public NavMeshAgent agent;
    private GamePhases phases;

    public GameObject target;
    public GameObject nextTarget;

    public GameObject targetFinder;

    public Animator _anim;

    public bool attacking;
    public bool dead;
    public bool trapped;
    public float maxSpeed;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        phases = GameObject.Find("GameManager").GetComponent<GamePhases>();
	}
	
	// Update is called once per frame
	void Update () {
        if(phases.gamePhases == Phases.FPS && trapped == false && dead == false && attacking == false)
        {
            agent.speed = maxSpeed;
            agent.isStopped = false;
            _anim.SetBool("Walking", true);
        }
        if(phases.gamePhases == Phases.Build || trapped == true || dead == true || attacking == true)
        {
            agent.speed = 0;
            agent.velocity = Vector3.zero;
            agent.isStopped = true;
            _anim.SetBool("Walking", false);
        }

        if(target == null)
        {
            targetFinder.SetActive(true);
        }
        else
        {
            targetFinder.SetActive(false);
        }
	}

    private void FixedUpdate()
    {
        if(GetComponent<Rigidbody>().isKinematic == true)
        {
           // Invoke("KinematicOff", 0.5f);
        }
    }

    void KinematicOff()
    {
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
