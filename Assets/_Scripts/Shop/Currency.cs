using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Currency : MonoBehaviour {

    public static Currency instance;

    public int money;
    public Text moneyText;

	// Use this for initialization
	void Awake () {
        instance = this;
	}

    private void FixedUpdate()
    {
        moneyText.text = "" + money;
    }
}
