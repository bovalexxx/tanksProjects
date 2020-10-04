using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTowerRotate : MonoBehaviour
{
    public Transform target;

    void FixedUpdate()
    {
        var newRotation = Quaternion.LookRotation(transform.position - target.position, Vector3.forward);
        Vector3 direction = target.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 16);
    }
}

