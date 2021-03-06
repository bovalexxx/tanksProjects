﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int EnemyHP = 100;
    public Slider slider;

    public GameObject other;

    void FixedUpdate()
    {
        if (EnemyHP <= 0)
        {
            Destroy(other);
        }
        slider.value = EnemyHP;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            EnemyHP = EnemyHP - 25;
        }
        if (col.gameObject.tag == "RocketBullet")
        {
            EnemyHP = EnemyHP - 100;
        }
    }
}

