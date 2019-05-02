using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTarget : MonoBehaviour {

    public GameObject target = null;
    public List<GameObject> targets = new List<GameObject>();

    // Use this for initialization
    private void FixedUpdate()
    {
        for (int i = targets.Count - 1; i > -1; i--)
        {
            if(targets[i] == null)
            {
                targets.RemoveAt(i);
                target = null;
            }
        }
    }
    private void Update()
    {
        if(targets.Count > 0)
        {
            target = targets[0];
        }
    }
}
