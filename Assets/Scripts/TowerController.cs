using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public GameObject bullet;
    public int bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
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
            projectile.GetComponent<Rigidbody2D>().AddForce(transform.up*bulletSpeed
                );
        }
    }
}
