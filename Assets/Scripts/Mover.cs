using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
	private Rigidbody rb;
	public float speed;

	void Update ()
	{
		transform.position += Vector3.right * (-speed * 0.01f);
	}
}
