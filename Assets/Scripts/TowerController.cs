using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public GameObject bullet;
    public int bulletSpeed;
    public GameObject RocketBullet2;
    public int RocketbulletSpeed;

    void Update()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle-90, Vector3.forward);

        if(Input.GetButtonDown("Fire1"))
        {
            GameObject projectile = Instantiate(bullet, transform.GetChild(0));
            projectile.transform.SetParent(null);
            projectile.GetComponent<Rigidbody2D>().AddForce(transform.up*bulletSpeed);
        }

        BonusRocket target = (BonusRocket)FindObjectOfType(typeof(BonusRocket));
        BonusRocket BonusRocket = target.GetComponent<BonusRocket>();

        if (Input.GetButtonDown("Fire2"))
        {
            if (BonusRocket.RocketHave >= 1)
            {
                GameObject projectile = Instantiate(RocketBullet2, transform.GetChild(0));
                projectile.transform.SetParent(null);
                projectile.GetComponent<Rigidbody2D>().AddForce(transform.up * RocketbulletSpeed);
                BonusRocket.RocketHave = BonusRocket.RocketHave - 1;
            }
        }
    }
}
