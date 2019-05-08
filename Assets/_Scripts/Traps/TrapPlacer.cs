using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlacer : MonoBehaviour {

    private GridTD grid;
    public GameObject trap;
    public int xSize;
    public int zSize;
    public LayerMask hitlayers;

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
            if (Physics.Raycast(ray, out hitInfo))
            {
                if(hitInfo.transform.gameObject.name == "Map")
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

        transform.localScale = new Vector3(xSize * grid.size, 50 * grid.size, zSize * grid.size);
        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.transform.gameObject.tag == "Map")
            {
                GetComponent<Renderer>().material.color = new Color(0, 1, 0, 0.39f);
                Debug.Log(hitInfo.transform.gameObject.name);
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
        Debug.Log("PlaceMine");
        var finalPosition = grid.GetNearestPointOnGrid(clickPoint);
        GameObject newObject = Instantiate(trap, finalPosition, Quaternion.identity) as GameObject;
        newObject.transform.localScale = new Vector3(xSize * grid.size, 50 * grid.size, zSize * grid.size);
        ShopMenu.instance.shopMenu.SetActive(true);
        Destroy(this.gameObject);
    }
}
