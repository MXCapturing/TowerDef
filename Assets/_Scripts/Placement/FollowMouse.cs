using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour {

    public LayerMask hitLayers;
    public Vector3 hitRound;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        Ray objectRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(objectRay, out hit, Mathf.Infinity, hitLayers))
        {
            hitRound = Vector3Int.RoundToInt(hit.point) + new Vector3Int(0,1,0);
            this.transform.position = hitRound;
        }
    }
}
