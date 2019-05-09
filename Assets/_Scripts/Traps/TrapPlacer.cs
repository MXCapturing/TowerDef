using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlacer : MonoBehaviour {

    public GameObject trap;
    public int xSize;
    public int ySize;
    public int zSize;
    public float yAxis;
    public LayerMask hitlayers;

    // Use this for initialization
    void Start () {
        References.instance.trapMap.SetActive(true);
        References.instance.camView.SetActive(true);
        References.instance.trapCam.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {

        RaycastHit hitInfo;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click");
            if (Physics.Raycast(ray, out hitInfo))
            {
                if(hitInfo.transform.gameObject.tag == "TrapMap" && hitInfo.transform.tag != "Trap")
                {
                    Debug.Log("Place");
                    GameObject newObject = Instantiate(trap, hitInfo.point, Quaternion.identity) as GameObject;
                    newObject.transform.localScale = new Vector3(xSize, ySize, zSize);
                    newObject.transform.rotation = hitInfo.transform.rotation;
                    newObject.transform.position = new Vector3(newObject.transform.position.x, yAxis, newObject.transform.position.z);
                    ShopMenu.instance.shopMenu.SetActive(true);
                    References.instance.trapMap.SetActive(false);
                    References.instance.trapCam.SetActive(false);
                    References.instance.camView.SetActive(false);
                    Destroy(this.gameObject);
                    //PlaceCubeNear(hitInfo.point);
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            ShopMenu.instance.shopMenu.SetActive(true);
            Destroy(this.gameObject);
        }
        if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, hitlayers))
        {
            References.instance.camView.transform.position = hitInfo.point + new Vector3(0,25,0);
        }

        transform.localScale = new Vector3(xSize , ySize , zSize );
        if (Physics.Raycast(ray, out hitInfo))
        {         
            if (hitInfo.transform.gameObject.tag == "TrapMap")
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

    /*private void PlaceCubeNear(Vector3 clickPoint)
    {
        Debug.Log("PlaceMine");
        GameObject newObject = Instantiate(trap, clickPoint, Quaternion.identity) as GameObject;
        newObject.transform.localScale = new Vector3(xSize, 50 , zSize);
        ShopMenu.instance.shopMenu.SetActive(true);
        Destroy(this.gameObject);
    }*/
}
