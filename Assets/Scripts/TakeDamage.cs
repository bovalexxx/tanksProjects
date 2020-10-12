using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public float TakeDamageINT;

    private void Start()
    {
        int TakeDamageINT = 0;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "EnemyBullet")
        {
            TakeDamageINT += 1;
        }
    }
}
