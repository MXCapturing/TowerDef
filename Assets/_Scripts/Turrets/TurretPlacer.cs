﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class TurretPlacer : MonoBehaviour {

    private GridTD grid;
    public GameObject turret;
    public int xSize;
    public int zSize;
    public LayerMask hitlayers;
    public int price;

	// Use this for initialization
	void Start () {
        grid = FindObjectOfType<GridTD>();
	}
	
	// Update is called once per frame
	void Update () {

        RaycastHit hitInfo;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray, out hitInfo))
            {
                if(hitInfo.transform.tag == "Map")
                {
                    PlaceCubeNear(hitInfo.point);
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            ShopMenu.instance.shopMenu.SetActive(true);
            Destroy(this.gameObject);
        }

        transform.localScale = new Vector3(xSize * grid.size, 50 * grid.size, zSize* grid.size);
        var hitCollidersColour = Physics.OverlapBox(gameObject.transform.position, new Vector3((xSize * grid.size)/20, grid.size * 100000, (zSize * grid.size)/20), Quaternion.identity, hitlayers);
        if(Physics.Raycast(ray, out hitInfo))
        {
            if (hitCollidersColour.Length <= 1 && hitInfo.transform.tag == "Map")
            {
                //GetComponent<Renderer>().material.
                GetComponent<Renderer>().material.color = new Color(0, 1, 0, 0.39f);
                Debug.Log(hitCollidersColour.Length);
            }
            else
            {
                GetComponent<Renderer>().material.color = new Color(1, 0, 0, 0.39f);
                Debug.Log("Red");
            }
        }
    }

    private void PlaceCubeNear(Vector3 clickPoint)
    {
        var finalPosition = grid.GetNearestPointOnGrid(clickPoint);
        var hitColliders = Physics.OverlapBox(gameObject.transform.position, new Vector3((xSize * grid.size)/20, grid.size * 100000, (zSize * grid.size)/20), Quaternion.identity, hitlayers);
        if(hitColliders.Length <= 1)
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<Currency>().money -= price;
            GameObject newObject = Instantiate(turret, finalPosition, Quaternion.identity) as GameObject;
            newObject.transform.localScale = new Vector3(xSize * grid.size, 50 * grid.size, zSize * grid.size);
            Analytics.CustomEvent("Placed Turret", new Dictionary<string, object>
            {
                {turret.name, 1 }
            });
            ShopMenu.instance.shopMenu.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
