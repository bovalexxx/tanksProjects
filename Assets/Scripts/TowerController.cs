using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerController : MonoBehaviour
{
    public GameObject tank;
    public TankController script;

    public bool cooldownOn = false;
    public float readyToFire = 1;
    public TankController tankController;
    public GameObject bullet;
    public int bulletSpeed;
    public GameObject rocketBullet;
    public int rocketbulletSpeed;
    public Text CooldownText;

    void Start()
    {
        script = tank.GetComponent<TankController>();
    }

    void Update()
    {
        CooldownText.text = readyToFire.ToString();

        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle-90, Vector3.forward);

        //Bullets
        if(Input.GetButtonDown("Fire1"))
        {
            if (script.bullets >= 1)
            {
                if(readyToFire >= 1f)
                {
                    GameObject projectile = Instantiate(bullet, transform.GetChild(0));
                    projectile.transform.SetParent(null);
                    projectile.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed);
                    script.bullets--;
                    readyToFire = 0;
                }
            }
        }

        //Rockets
        if (Input.GetButtonDown("Fire2"))
        {
            if (tankController.rockets >= 1)
            {
                    GameObject projectile = Instantiate(rocketBullet, transform.GetChild(0));
                    projectile.transform.SetParent(null);
                    projectile.GetComponent<Rigidbody2D>().AddForce(transform.up * rocketbulletSpeed);
                    tankController.rockets--;                
            }
        }

        if (readyToFire < 1)
        {
            if (cooldownOn == false)
            {
                StartCoroutine("Cooldown");
                cooldownOn = true;
            }
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(0.1f);
        readyToFire = readyToFire +  0.1f;
        cooldownOn = false;
    }
}
