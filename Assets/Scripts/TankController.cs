using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankController : MonoBehaviour
{
    [Header("Movement")]
    public GameObject trackLeft;
    public GameObject trackRight;
    public GameObject shieldObj;

    public string keyMoveForward;
    public string keyMoveReverse;
    public string keyRotateRight;
    public string keyRotateLeft;

    bool moveForward = false;
    bool moveReverse = false;
    float moveSpeed = 0f;
    float moveSpeedReverse = 0f;
    float moveAcceleration = 0.1f;
    float moveDeceleration = 0.20f;
    float moveSpeedMax = 2f;

    bool rotateRight = false;
    bool rotateLeft = false;
    float rotateSpeedRight = 0f;
    float rotateSpeedLeft = 0f;
    float rotateAcceleration = 4f;
    float rotateDeceleration = 10f;
    float rotateSpeedMax = 130f;

    public string useFirstAid;
    public string useShield;
    //Other
    [Header("Setup")]
    public int health = 100;
    public int bullets = 20;
    public int rockets = 0;
    public int shieldsHave = 0;
    public int firstAid = 0;
    public bool shields = false;
    [Header("UI")]
    public Slider healthSlider;
    public Text healthText;
    public Text RocketsText;
    public Text ShieldsText;
    public Text FirstAidText;
    public Text BulletsText;

    void Start()
    {
        shieldObj.SetActive(false);
    }

    void Update()
    {
        
        rotateLeft = (Input.GetKeyDown(keyRotateLeft)) ? true : rotateLeft;
        rotateLeft = (Input.GetKeyUp(keyRotateLeft)) ? false : rotateLeft;
        if (rotateLeft)
        {
            rotateSpeedLeft = (rotateSpeedLeft < rotateSpeedMax) ? rotateSpeedLeft + rotateAcceleration : rotateSpeedMax;
        }
        else
        {
            rotateSpeedLeft = (rotateSpeedLeft > 0) ? rotateSpeedLeft - rotateDeceleration : 0;
        }
        transform.Rotate(0f, 0f, rotateSpeedLeft * Time.deltaTime);

        rotateRight = (Input.GetKeyDown(keyRotateRight)) ? true : rotateRight;
        rotateRight = (Input.GetKeyUp(keyRotateRight)) ? false : rotateRight;
        if (rotateRight)
        {
            rotateSpeedRight = (rotateSpeedRight < rotateSpeedMax) ? rotateSpeedRight + rotateAcceleration : rotateSpeedMax;
        }
        else
        {
            rotateSpeedRight = (rotateSpeedRight > 0) ? rotateSpeedRight - rotateDeceleration : 0;
        }
        transform.Rotate(0f, 0f, rotateSpeedRight * Time.deltaTime * -1f);

        moveForward = (Input.GetKeyDown(keyMoveForward)) ? true : moveForward;
        moveForward = (Input.GetKeyUp(keyMoveForward)) ? false : moveForward;
        if (moveForward)
        {
            moveSpeed = (moveSpeed < moveSpeedMax) ? moveSpeed + moveAcceleration : moveSpeedMax;
            GetComponent<Rigidbody2D>().AddForce(transform.up * moveSpeed * 2);
        }
        else
        {
            moveSpeed = (moveSpeed > 0) ? moveSpeed - moveDeceleration : 0;
        }
        
        //transform.Translate(0f, moveSpeed * Time.deltaTime*4, 0f);

        moveReverse = (Input.GetKeyDown(keyMoveReverse)) ? true : moveReverse;
        moveReverse = (Input.GetKeyUp(keyMoveReverse)) ? false : moveReverse;
        if (moveReverse)
        {
            moveSpeedReverse = (moveSpeedReverse < moveSpeedMax) ? moveSpeedReverse + moveAcceleration : moveSpeedMax;
            GetComponent<Rigidbody2D>().AddForce(transform.up * -moveSpeedReverse * 1);
        }
        else
        {
            moveSpeedReverse = (moveSpeedReverse > 0) ? moveSpeedReverse - moveDeceleration : 0;
        }
        //transform.Translate(0f, moveSpeedReverse * Time.deltaTime * -1f, 0f);

        if (moveForward | moveReverse | rotateRight | rotateLeft)
        {
            trackStart();
        }
        else
        {
            trackStop();
        }

        if (Input.GetKeyDown(useFirstAid))
        {
            if (firstAid >= 1)
            {
                health += 20;
                if (health > 100)
                    health = 100;
                firstAid--;
            }
        }
        if (Input.GetKeyDown(useShield))
        {
            if (shieldsHave >= 1)
            {
                StartCoroutine("shieldStart");
                shieldsHave--;
            }
        }
    }

    void trackStart()
    {
        trackLeft.GetComponent<Animator>().SetBool("isMoving", true);
        trackRight.GetComponent<Animator>().SetBool("isMoving", true);
    }

    void trackStop()
    {
        trackLeft.GetComponent<Animator>().SetBool("isMoving", false);
        trackRight.GetComponent<Animator>().SetBool("isMoving", false);
    }
    //UI
    void FixedUpdate()
    {
        healthSlider.value = health;
        healthText.text = health.ToString();
        RocketsText.text = rockets.ToString();
        ShieldsText.text = shieldsHave.ToString();
        FirstAidText.text = firstAid.ToString();
        BulletsText.text = bullets.ToString();
    }
    //Colliders & Triggers
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "FirstAid")
        {
            Destroy(col.gameObject);
            firstAid++;
        }
        if (col.gameObject.tag == "BonusRocket")
        {
            Destroy(col.gameObject);
            rockets++;
        }
        if (col.gameObject.tag == "Shield")
        {
            Destroy(col.gameObject);
            shieldsHave++;
        }
        if (col.gameObject.tag == "BonusBullets")
        {
            Destroy(col.gameObject);
            bullets += 5;
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "EnemyBullet")
        {
            if (shields == false)
            {
            health -= 20;
            }
        }
    }

    IEnumerator shieldStart()
    {
        shieldObj.SetActive(true);
        shields = true;
        yield return new WaitForSeconds(10f);
        shields = false;
        shieldObj.SetActive(false);
    }
}
