using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBullet : MonoBehaviour
{
    public GameObject RocketBullet2;
    public int RocketbulletSpeed;

    void Update()
    {
        BonusRocket target = (BonusRocket)FindObjectOfType(typeof(BonusRocket));
        BonusRocket BonusRocket = target.GetComponent<BonusRocket>();

        if (Input.GetButtonDown("Fire2"))
        {
            if (BonusRocket.RocketHave >= 1)
            {
                GameObject projectile = Instantiate(RocketBullet2, transform.GetChild(0));
                projectile.transform.SetParent(null);
                projectile.GetComponent<Rigidbody2D>().AddForce(transform.up * RocketbulletSpeed);
            }
        }
    }
}
