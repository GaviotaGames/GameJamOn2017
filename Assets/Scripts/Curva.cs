using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curva : MonoBehaviour {

	public float amplitude = 1f;
	public float longitude = 1f;
	public float separacion = 1f;

  // El objeto al que seguir con amplitud y longitud
  public Personaje follow = null;

	private float posX = 0f;
	private float posY = 0f;
	private LineRenderer lineRend = null;

	public float amplitudeChangePerSecond = 0.007f;
	public float longitudeChangePerSecond = 0.2f;
	public float threshold = 0.2f;

	public float amplitudeMax = 1f;
	public float amplitudeMin = 1f;
	public float longitudeMax = 5f;
	public float longitudeMin = 0f;

	void Start (){
		lineRend = GetComponent <LineRenderer>();
	}

  void FixedUpdate () {
    if (follow != null) {
      this.amplitude = follow.amplitude;
      this.longitude = follow.longitude;
    }
  }

	void Update () {
		controls ();

		for (int i = 0; i < lineRend.numPositions; i++) {
			posX = transform.position.x + separacion * i;
			posY = (Mathf.Sin(Time.time + posX * longitude)) * amplitude;
			lineRend.SetPosition (i, new Vector3 (posX, posY, transform.position.z));
		}
	}

	private void controls() {
		if (Mathf.Abs (Input.GetAxis ("Horizontal")) > threshold) {
			longitude = Mathf.Lerp (longitude, longitude - Mathf.Sign (Input.GetAxis ("Horizontal")), longitudeChangePerSecond * Time.deltaTime);
			if (longitude <= longitudeMin) {
				longitude = longitudeMin;
			} else if (longitude >= longitudeMax) {
				longitude = longitudeMax;
			}
		}
		if (Mathf.Abs (Input.GetAxis ("Vertical")) > threshold) {
				amplitude = Mathf.Lerp (amplitude, amplitude + Mathf.Sign (Input.GetAxis ("Vertical")), amplitudeChangePerSecond * Time.deltaTime);
			if (amplitude <= amplitudeMin) {
				amplitude = amplitudeMin;
			} else if (amplitude >= amplitudeMax) {
				amplitude = amplitudeMax;
			}
		}
	}
}
