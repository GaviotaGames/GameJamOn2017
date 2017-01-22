using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoGlobal : MonoBehaviour
{
	public float speed;

	void Update ()
	{
		transform.position += Vector3.right * (speed * 0.01f);
	}
}
