using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBullet : MonoBehaviour
{
	public GameObject other;

	private void OnCollisionEnter2D(Collision2D col)
	{
         Destroy(other);
	}
}
