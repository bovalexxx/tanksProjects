using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstAid : MonoBehaviour
{
	public bool NeedAdd = false;
	public GameObject other;

	private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "FirstAid")
		{
			Destroy(other);
			NeedAdd = true;
		}
	}
}