using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HP_Script : MonoBehaviour {

    public float currentHP = 450;
    public float maxHP = 450;

    public Transform healthMeter;
    public Image hP_Slider;

    void Start ()
    {
        healthMeter.GetComponent<Image> ().color = new Color (1, 1, 1);
    }

    void Update ()
    {


        if (currentHP/maxHP <= 0.2f)
        {
            healthMeter.GetComponent<Image> ().color = new Color (1, 0, 0);
        
        }

        else
        {
            healthMeter.GetComponent<Image>().color = new Color(1, 1, 1);
        }

        hP_Slider.fillAmount = currentHP / maxHP;

        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
   
    }
          
}
