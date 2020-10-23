using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBorders : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.localScale.x > 0.1f)
            gameObject.transform.localScale -= new Vector3(0.00001f, 0.00001f, 0);
    }
}
