using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTowerRotate : MonoBehaviour
{
    public float speed;

    private Transform target;

    public GameObject Enemybullet;
    public int EnemybulletSpeed;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        StartCoroutine(BulletPiu());
    }

    IEnumerator BulletPiu()
    {
        yield return new WaitForSeconds(5f);
        GameObject projectile = Instantiate(Enemybullet, transform.GetChild(2));
        projectile.transform.SetParent(null);
        projectile.GetComponent<Rigidbody2D>().AddForce(transform.up * EnemybulletSpeed);
        StartCoroutine(BulletPiu());
    }

    void Update()
    {

            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            var newRotation = Quaternion.LookRotation(transform.position - target.position, Vector3.forward);
            newRotation.x = 0.0f;
            newRotation.y = 0.0f;
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 16);       
    }
}

