using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarScript : MonoBehaviour
{
    public float HealthINT;
    public Slider slider;
    public Text HP;
    public string HealthSTR;

    void FixedUpdate()
    {
        FirstAid target = (FirstAid)FindObjectOfType(typeof(FirstAid));
        FirstAid FirstAid = target.GetComponent<FirstAid>();
        HealthSTR = HealthINT.ToString();
        slider.value = HealthINT;
        HP.text = HealthSTR;
        if (FirstAid.NeedAdd == true)
        {
            HealthINT = 100;
        }
    }


}
