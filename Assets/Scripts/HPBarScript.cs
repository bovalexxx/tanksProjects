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
    public GameObject other;

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
            FirstAid.NeedAdd = false;
        }
        TakeDamage target2 = (TakeDamage)FindObjectOfType(typeof(TakeDamage));
        TakeDamage TakeDamage = target2.GetComponent<TakeDamage>();
        if (TakeDamage.TakeDamageINT >= 1)
        {
            HealthINT -= 25;
            TakeDamage.TakeDamageINT -= 1;
        }
    }
}
