using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Base_HP : MonoBehaviour {

    public float north_HP_current = 1000;
    public float east_HP_current = 1000;
    public float south_HP_current = 1000;
    public float west_HP_current = 1000;

    public float north_HP_max = 1000;
    public float east_HP_max = 1000;
    public float south_HP_max = 1000;
    public float west_HP_max = 1000;

    public Transform healthMeterNorth;
    public Transform healthMeterEast;
    public Transform healthMeterSouth;
    public Transform healthMeterWest;

    public Image doorNorth_Slider;
    public Image doorEast_Slider;
    public Image doorSouth_Slider;
    public Image doorWest_Slider;

    void Start()
    {
        healthMeterNorth.GetComponent<Image>().color = new Color(1, 1, 1);
        healthMeterEast.GetComponent<Image>().color = new Color(1, 1, 1);
        healthMeterSouth.GetComponent<Image>().color = new Color(1, 1, 1);
        healthMeterWest.GetComponent<Image>().color = new Color(1, 1, 1);
    }

    void Update()
    {
        //north door HP bar turn red when low, else white
        if (north_HP_current / north_HP_max <= 0.2f)
        {
            healthMeterNorth.GetComponent<Image>().color = new Color(1, 0, 0);
        }

        else
        {
            healthMeterNorth.GetComponent<Image>().color = new Color(1, 1, 1);
        }

        //north door HP bar
        doorNorth_Slider.fillAmount = north_HP_current / north_HP_max;

        //max HP cannot drop below 1000
        if (north_HP_max < 1000f)
        {
            north_HP_max = 1000f;
        }

        //current HP cannot be higher than max HP
        if (north_HP_current > north_HP_max)
        {
            north_HP_current = north_HP_max;
        }

        //east door
        if (east_HP_current / east_HP_max <= 0.2f)
        {
            healthMeterEast.GetComponent<Image>().color = new Color(1, 0, 0);
        }

        else
        {
            healthMeterEast.GetComponent<Image>().color = new Color(1, 1, 1);
        }

        doorEast_Slider.fillAmount = east_HP_current / east_HP_max;

        if (east_HP_max < 1000f)
        {
            east_HP_max = 1000f;
        }

        if (east_HP_current > east_HP_max)
        {
            east_HP_current = east_HP_max;
        }

        //south door
        if (south_HP_current / south_HP_max <= 0.2f)
        {
            healthMeterSouth.GetComponent<Image>().color = new Color(1, 0, 0);
        }

        else
        {
            healthMeterSouth.GetComponent<Image>().color = new Color(1, 1, 1);
        }

        doorSouth_Slider.fillAmount = south_HP_current / south_HP_max;

        if (south_HP_max < 1000f)
        {
            south_HP_max = 1000f;
        }

        if (south_HP_current > south_HP_max)
        {
            south_HP_current = south_HP_max;
        }

        //west door
        if (west_HP_current / west_HP_max <= 0.2f)
        {
            healthMeterWest.GetComponent<Image>().color = new Color(1, 0, 0);
        }

        else
        {
            healthMeterWest.GetComponent<Image>().color = new Color(1, 1, 1);
        }

        doorWest_Slider.fillAmount = west_HP_current / west_HP_max;

        if (west_HP_max < 1000f)
        {
            west_HP_max = 1000f;
        }

        if (west_HP_current > west_HP_max)
        {
            west_HP_current = west_HP_max;
        }
    }

}
