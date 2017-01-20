using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour {

	public float amplitud = 1f;
	public float longitud = 1f;

	private float posY = 0f;

	void Update () {
		posY = (Mathf.Sin(Time.time * longitud + transform.position.x * longitud)) * amplitud;
		transform.position = new Vector3 (transform.position.x, posY, transform.position.z);
	}
}
