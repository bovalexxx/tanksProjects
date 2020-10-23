using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTowerRotate : MonoBehaviour
{
    public float speed;

    private Transform target;
    private Vector3 randomPoint;

    public GameObject Enemybullet;
    public int EnemybulletSpeed;
    public EnemyAI tankBase;

    void Start()
    {
        StartCoroutine("ChooseRandomTarget");
        tankBase = transform.parent.parent.GetComponent<EnemyAI>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        StartCoroutine(BulletPiu());
    }

    IEnumerator BulletPiu()
    {
        yield return new WaitForSeconds(5f);
        if (tankBase.chooseRandom == false)
        {
            GameObject projectile = Instantiate(Enemybullet, transform.GetChild(2));
            projectile.transform.SetParent(null);
            projectile.GetComponent<Rigidbody2D>().AddForce(transform.up * EnemybulletSpeed);
        }
        StartCoroutine(BulletPiu());
    }

    void Update()
    {
        if (tankBase.chooseRandom == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            var newRotation = Quaternion.LookRotation(transform.position - target.position, Vector3.forward);
            newRotation.x = 0.0f;
            newRotation.y = 0.0f;
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 16);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, randomPoint, speed * Time.deltaTime);
            var newRotation = Quaternion.LookRotation(transform.position - randomPoint, Vector3.forward);
            newRotation.x = 0.0f;
            newRotation.y = 0.0f;
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 16);
        }
    }
    IEnumerator ChooseRandomTarget()
    {
        yield return new WaitForSeconds(Random.Range(1, 5));
        if (tankBase.chooseRandom)
            randomPoint = new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), 0);
        StartCoroutine("ChooseRandomTarget");
    }

}

