using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    private GameObject player;
    public Vector3 target;
    public int speed = 4;
    public bool chooseRandom = true;
    public bool isIdle;
    public bool isFollowTarget;
    public bool shieldsActive = false;

    public int EnemyHP = 100;
    public Slider slider;

    public GameObject other;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        StartCoroutine("ChooseRandomTarget");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) > 5)
            FollowTarget();
        PlayerDistance();

        if (EnemyHP <= 0)
        {
            Destroy(other);
        }
        slider.value = EnemyHP;
    }
    void PlayerDistance()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 30)
        {
            if (Vector3.Distance(transform.position, player.transform.position) > 5)
                target = player.transform.position;
            chooseRandom = false;
        }
        else
            chooseRandom = true;

    }
    void Idle()
    {

    }
    void ChooseRandomTargetd()
    {
        //target = new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), 0);
    }
    void FollowTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        var newRotation = Quaternion.LookRotation(transform.position - target, Vector3.forward);
        newRotation.x = 0.0f;
        newRotation.y = 0.0f;
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 1.5f);
    }
    void Attack()
    {

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            if (shieldsActive == false)
            {
                EnemyHP = EnemyHP - 25;
            }
        }
        if (col.gameObject.tag == "RocketBullet")
        {
            if(shieldsActive == false)
            {
                EnemyHP = EnemyHP - 100;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "FirstAid")
        {
            Destroy(col.gameObject);
            EnemyHP += 20;
        }
        if (col.gameObject.tag == "Shield")
        {
            Destroy(col.gameObject);
            StartCoroutine("shieldStart");
        }
    }

    private IEnumerator shieldStart()
    {
        shieldsActive = true;
        yield return new WaitForSeconds(10f);
        shieldsActive = false;
    }

    private IEnumerator ChooseRandomTarget()
    {
        yield return new WaitForSeconds(Random.Range(1, 5));
        if (chooseRandom)
            target = new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), 0);
        StartCoroutine("ChooseRandomTarget");
    }
}
