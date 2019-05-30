using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectonGrid : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GamePhases.instance.gamePhases == Phases.Build && Input.GetMouseButtonDown(0) && ShopMenu.instance.mapView == true)
        {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit)
            {
                Debug.Log("Click");
                if (hitInfo.transform.gameObject.tag == "Turret" || hitInfo.transform.gameObject.tag == "Trap")
                {
                    References.instance.turretChosen = hitInfo.transform.gameObject;
                    hitInfo.transform.GetComponent<TurretInfo>().SetInfoOn();
                }
            }
        }
	}
}
