using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaA : MonoBehaviour {
	
	public Curva follow = null;
    
	private float amplitude = 1f;
	private float longitude = 1f;
	private float speed = 1f;
	private float finalSpeed = 1f;
	public float bulletSpeedMax = 2f;
	public float bulletSpeedMin = 0.2f;
	private float bulletSpeed = 1f;
	private float posX = 0f;
	private float posY = 0f;
	private float offset = 7f;


	void Start(){
		GameObject curvObj = GameObject.FindGameObjectWithTag ("curvaA");
		follow = curvObj.GetComponent<Curva> ();
	}

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

		finalSpeed = speed * 1f;

		if (transform.position.x > 7f + 3f) {
			follow.bulletCount -= 1;
			Destroy (gameObject);
		}
	}

	private void movement() {
		bulletSpeed = Mathf.Lerp (bulletSpeedMax, bulletSpeedMin, longitude);
		posX = transform.position.x + bulletSpeed * Time.deltaTime;
		posY = (Mathf.Sin (finalSpeed*Time.time + (transform.position.x + offset) * longitude)) * amplitude;
		transform.position = new Vector3 (posX, posY, transform.position.z);
	}

	void OnTriggerEnter (Collider other){
		if ((other.gameObject.tag == "p2") || (other.gameObject.tag == "balaB")) {
			ExtraLives lives = other.gameObject.GetComponent<ExtraLives>();
			if (lives != null) {
				lives.takeALife();
			}
			follow.bulletCount -= 1;
			Destroy (gameObject);
		}
	}
}
