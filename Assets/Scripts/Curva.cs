using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curva : MonoBehaviour {

	public float amplitud = 1f;
	public float longitud = 1f;
	public float separacion = 1f;

  // El objeto al que seguir con amplitud y longitud
  public Personaje follow = null;

	private float posX = 0f;
	private float posY = 0f;
	private LineRenderer lineRend = null;

	void Start () {
		lineRend = GetComponent <LineRenderer>();
	}

  void FixedUpdate () {
    if (follow != null) {
      this.amplitud = follow.amplitude;
      this.longitud = follow.longitude;
    }
  }

	void Update () {
		for (int i = 0; i < lineRend.numPositions; i++) {
			posX = transform.position.x + separacion * i;
			posY = (Mathf.Sin(Time.time * longitud + posX * longitud)) * amplitud;
			lineRend.SetPosition (i, new Vector3 (posX, posY, transform.position.z));
		}
	}
}
