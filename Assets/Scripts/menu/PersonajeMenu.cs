using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeMenu : MonoBehaviour {

	public float separacion = 1f;
	public float amplitude = 1f;
	public float longitude = 1f;
	public float finalSpeed = 2f;
	public float offsetY = 0f;

	private float posY = 0f;
	private float posX = -3.6f;
	private float oldPosX = 0f;

	public CurvaMenu follow = null;


	
	// Update is called once per frame
	void Update () {

		oldPosX = posX;
		if (follow != null) {
			this.amplitude = follow.amplitude;
			this.longitude = follow.longitude;
			this.finalSpeed = follow.finalSpeed;
			this.posX = follow.persX;
		}

		posX = Mathf.Lerp (oldPosX, posX, 3f * Time.deltaTime);
		posY = (Mathf.Sin (finalSpeed * Time.time + posX * longitude)) * amplitude;
		transform.position = new Vector3 (posX, posY + offsetY, transform.position.z);
		
	}
}
