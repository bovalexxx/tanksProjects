﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public GameObject other;

	private void OnCollisionEnter2D(Collision2D col)
	{
			Destroy(other);
	}
}
