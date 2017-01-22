using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curva1 : MonoBehaviour {

	public float amplitude = 1f;
	public float longitude = 1f;
	public float separacion = 1f;
	public float amplitudeChangePerSecond = 0.007f;
	public float longitudeChangePerSecond = 0.2f;
	public float threshold = 0.2f;
	public float amplitudeMax = 1f;
	public float amplitudeMin = 1f;
	public float longitudeMax = 5f;
	public float longitudeMin = 0f;
	public float amplitudeMaxMantener = 2f;
	public float amplitudeMinMantener = 0.2f;
	public float longitudeMaxMantener = 3f;
	public float longitudeMinMantener = 0.2f;
	public float speed = 1f;
	public bool mantenerX = false;
	public bool mantenerY = false;
	public float offset = 7f;
	public GameObject balaB = null;
	private float dodge = 0f;
	public float dodgeMax = 1.3f;
	public int bulletCount = 0;
	public int bulletMax = 3;

	private float posX = 0f;
	private float posY = 0f;
	private LineRenderer lineRend = null;
	private float finalSpeed = 1f;


	void Start (){
		lineRend = GetComponent <LineRenderer>();
	}

	void Update () {
		shoot ();
		controls ();

		finalSpeed = speed * -1f;
		for (int i = 0; i < lineRend.numPositions; i++) {
			posX = transform.position.x + separacion * i;
			posY = (Mathf.Sin(finalSpeed*Time.time + (posX + offset) * longitude)) * amplitude;
			lineRend.SetPosition (i, new Vector3 (posX, posY, transform.position.z));
		}
	}

	private void shoot() {
		//if (Input.GetKeyDown (KeyCode.RightControl)){
		if (Input.GetButtonDown ("Fire2")){
			if (bulletCount < bulletMax) {
				float posYInst = (Mathf.Sin(finalSpeed*Time.time + (7) * longitude)) * amplitude;
				dodge = Mathf.Lerp(7f, 7f-dodgeMax, Mathf.Clamp01(Input.GetAxis ("Horizontal2") * -1f));
				Instantiate (balaB, transform.position + Vector3.right * (3f+dodge) + Vector3.up * posYInst, Quaternion.identity);
				bulletCount += 1;
			}
		}
	}

	private void controls() {
		if (!mantenerX) {
			if (Mathf.Abs (Input.GetAxis ("Horizontal2")) > threshold) {
				longitude = Mathf.Lerp (longitude, longitude + Mathf.Sign (Input.GetAxis ("Horizontal2")), longitudeChangePerSecond * Time.deltaTime);
				if (longitude <= longitudeMin) {
					longitude = longitudeMin;
				} else if (longitude >= longitudeMax) {
					longitude = longitudeMax;
				}
			}
		} else {
			if (Input.GetAxis("Horizontal2") > threshold) {
				longitude = Mathf.Lerp (longitude, longitudeMinMantener, longitudeChangePerSecond * Time.deltaTime);
			} else {
				longitude = Mathf.Lerp (longitude, longitudeMaxMantener, longitudeChangePerSecond * Time.deltaTime);
			}
		}


		if (!mantenerY) {
			if (Mathf.Abs (Input.GetAxis ("Vertical2")) > threshold) {
				amplitude = Mathf.Lerp (amplitude, amplitude + Mathf.Sign (Input.GetAxis ("Vertical2")), amplitudeChangePerSecond * Time.deltaTime);
				if (amplitude <= amplitudeMin) {
					amplitude = amplitudeMin;
				} else if (amplitude >= amplitudeMax) {
					amplitude = amplitudeMax;
				}
			}
		} else {
			if (Input.GetAxis("Vertical2") > threshold) {
				amplitude = Mathf.Lerp (amplitude, amplitudeMaxMantener, amplitudeChangePerSecond * Time.deltaTime);
			} else {
				amplitude = Mathf.Lerp (amplitude, amplitudeMinMantener, amplitudeChangePerSecond * Time.deltaTime);
			}
		}
	}
}
