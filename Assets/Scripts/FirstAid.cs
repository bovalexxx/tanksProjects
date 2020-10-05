using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstAid : MonoBehaviour
{
	public bool NeedAdd = false;

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Player")
		{
			Destroy(gameObject, 7f);
			NeedAdd = true;
		}
	}
}