using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje1 : MonoBehaviour {
	
	public Curva1 follow = null;
    
	private float amplitude = 1f;
	private float longitude = 1f;
	private float speed = 1f;
	private float finalSpeed = 1f;
	private float posY = 0f;
	private float offset = 7f;
	private float dodge = 0f;
	public float dodgeMax = 1.3f;


	void FixedUpdate () {
		if (follow != null) {
			this.amplitude = follow.amplitude;
			this.longitude = follow.longitude;
			this.speed = follow.speed;
			this.offset = follow.offset;
		}
	}

	void Update () {
		movement();

		finalSpeed = speed * -1f;
	}

	private void movement() {
		dodge = Mathf.Lerp(7f, 7f-dodgeMax, Mathf.Clamp01(Input.GetAxis ("Horizontal2")));
		posY = (Mathf.Sin (finalSpeed*Time.time + (transform.position.x + offset) * longitude)) * amplitude;
		transform.position = new Vector3 (dodge, posY, transform.position.z);
	}
}
