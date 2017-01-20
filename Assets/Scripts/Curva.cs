using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curva : MonoBehaviour {

	public float amplitud = 1f;
	public float longitud = 1f;
	public float separacion = 1f;

	private float posX = 0f;
	private float posY = 0f;
	private LineRenderer lineRend = null;

	void Start (){
		lineRend = GetComponent <LineRenderer>();
	}

	void Update () {
		
		for (int i = 0; i < lineRend.numPositions; i++) {
			posX = transform.position.x + separacion * i;
			posY = (Mathf.Sin(Time.time * longitud + posX * longitud)) * amplitud;
			lineRend.SetPosition (i, new Vector3 (posX, posY, transform.position.z));
		}

		//posY = (Mathf.Sin(Time.time + transform.position.x * longitud)) * amplitud;
		//transform.position = new Vector3 (transform.position.x, posY, transform.position.z);
	}
}
