using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour {
	
	public Curva follow = null;
    
	private float amplitude = 1f;
	private float longitude = 1f;
	private float finalSpeed = 2f;
	private float posY = 0f;

	void FixedUpdate () {
		if (follow != null) {
			this.amplitude = follow.amplitude;
			this.longitude = follow.longitude;
			this.finalSpeed = follow.finalSpeed;
		}
	}

	void Update () {
		movement();
	}

	private void movement() {
		posY = (Mathf.Sin (finalSpeed * Time.time + transform.position.x * longitude)) * amplitude;
		transform.position = new Vector3 (transform.position.x, posY, transform.position.z);
	}
}
