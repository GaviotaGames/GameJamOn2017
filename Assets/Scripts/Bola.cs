using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour {
  public float amplitude = 100;
  public float hspeed = 60;
  public float hspeedChangePerSecond = 5;
  public float amplitudeChangePerSecond = 5;

  void Update () {
    hspeed += Input.GetAxis("Horizontal") * hspeedChangePerSecond * Time.deltaTime;
    amplitude += Input.GetAxis("Vertical") * amplitudeChangePerSecond * Time.deltaTime;
  }

	// Update is called once per frame
	void FixedUpdate () {
    transform.position = new Vector3(transform.position.x + hspeed * Time.deltaTime, amplitude * Mathf.Sin(Time.time), 0.0f);
  }
}
