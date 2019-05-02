using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour {

    public static Currency instance;

    public int money;

	// Use this for initialization
	void Awake () {
        instance = this;
	}
}
