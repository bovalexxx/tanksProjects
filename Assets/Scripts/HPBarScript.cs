using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarScript : MonoBehaviour
{
    public int HealthINT;
    public Slider slider;
    public Text HP;
    public string HealthSTR;

    void FixedUpdate()
    {
        HealthSTR = HealthINT.ToString();
        slider.value = HealthINT;
        HP.text = HealthSTR;
    }


}
