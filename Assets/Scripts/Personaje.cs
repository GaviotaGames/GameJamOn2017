using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour {

	public float amplitude = 1f;
	public float longitude = 1f;

  public float amplitudeChangePerSecond = 0.007f;
  public float longitudeChangePerSecond = 0.2f;
  public float threshold = 0.2f;

  private float posY = 0f;

  void Update () {
    controls();
    movement();
	}

  private void movement() {
    posY = (Mathf.Sin(Time.time * longitude + transform.position.x * longitude)) * amplitude;
    transform.position = new Vector3(transform.position.x, posY, transform.position.z);
  }

  private void controls() {
    if (Mathf.Abs(Input.GetAxis("Horizontal")) > threshold) {
      longitude = Mathf.Lerp(longitude, longitude + Mathf.Sign(Input.GetAxis("Horizontal")), longitudeChangePerSecond * Time.deltaTime);
    }
    if (Mathf.Abs(Input.GetAxis("Vertical")) > threshold) {
      amplitude = Mathf.Lerp(amplitude, amplitude + Mathf.Sign(Input.GetAxis("Vertical")), amplitudeChangePerSecond * Time.deltaTime);
    }
  }
}
