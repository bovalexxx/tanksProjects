using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject Enemybullet;
    public int EnemybulletSpeed;

    void Start()
    {
        StartCoroutine(BulletPiu());
    }

    IEnumerator BulletPiu()
    {
        yield return new WaitForSeconds(5f);
        GameObject projectile = Instantiate(Enemybullet, transform.GetChild(0));
        projectile.transform.SetParent(null);
        projectile.GetComponent<Rigidbody2D>().AddForce(transform.up * EnemybulletSpeed);
        StartCoroutine(BulletPiu());
    }
}
