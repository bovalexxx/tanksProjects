using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusRocket : MonoBehaviour
{
	public int RocketHave = 0;
	public GameObject otherObj;

	private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "BonusRocket")
		{
			Destroy(otherObj);
			RocketHave = RocketHave + 1;
		}
	}
}
