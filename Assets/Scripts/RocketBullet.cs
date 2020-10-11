using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBullet : MonoBehaviour
{
    public GameObject other;

    private void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(other);
    }
}
