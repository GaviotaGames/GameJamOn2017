using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour {
	
	public Curva follow = null;
    
	private float amplitude = 1f;
	private float longitude = 1f;
	private float speed = 1f;
	private float finalSpeed = 1f;
	private float posY = 0f;
	private float dodge = 0f;
	public float dodgeMax = 1.3f;

	void FixedUpdate () {
		if (follow != null) {
			this.amplitude = follow.amplitude;
			this.longitude = follow.longitude;
			this.speed = follow.speed;
		}
	}

	void Update () {
		movement();

		finalSpeed = speed;
	}

	private void movement() {
		dodge = Mathf.Lerp(0f, dodgeMax, Input.GetAxis ("Horizontal"));
		posY = (Mathf.Sin (finalSpeed*Time.time + (transform.position.x) * longitude)) * amplitude;
		transform.position = new Vector3 (dodge, posY, transform.position.z);
	}
}
