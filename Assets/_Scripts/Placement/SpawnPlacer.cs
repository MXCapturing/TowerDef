using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlacer : MonoBehaviour {

    public GameObject machineGun;
    public GameObject cube;

    public void SpawnMachineGun()
    {
        Instantiate(machineGun, Vector3.zero, Quaternion.identity);
    }

    public void SpawnPlaceholderGun()
    {
        Instantiate(cube, Vector3.zero, Quaternion.identity);
    }
}
