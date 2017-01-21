using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour {

	public float amplitude = 1f;
	public float longitude = 1f;

	private float posY = 0f;

	public Curva follow = null;

	void FixedUpdate () {
		if (follow != null) {
			this.amplitude = follow.amplitude;
			//this.longitude = follow.longitude;
		}
	}

	void Update () {
		movement();
	}

	private void movement() {
		posY = (Mathf.Sin (Time.time * longitude + transform.position.x * longitude)) * amplitude;
		transform.position = new Vector3 (transform.position.x, posY, transform.position.z);
	}
}
