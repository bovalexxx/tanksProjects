using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
	public GameObject me;

	private void OnCollisionEnter2D(Collision2D col)
	{
			Destroy(me);
		if (col.gameObject.tag == "BrokeBlock")
			Destroy(col.gameObject);
	}
}
