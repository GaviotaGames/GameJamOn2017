using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvaMenu : MonoBehaviour {

	public float amplitude = 1f;
	public float longitude = 1f;
	public float separacion = 1f;
	public float speed = 2f;
	public float finalSpeed = 2f;
	public float offsetY = 0f;
	public float[] persPos;
	public float persX;

	private float posX = 0f;
	private float posY = 0f;
	private LineRenderer lineRend = null;
	private int ind = 0;
	private bool activo = false;

	// Use this for initialization
	void Start () {
		lineRend = GetComponent <LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

		finalSpeed = speed;
		for (int i = 0; i < lineRend.numPositions; i++) {
			posX = transform.position.x + separacion * i;
			posY = (Mathf.Sin (finalSpeed * Time.time + posX * longitude)) * amplitude;
			lineRend.SetPosition (i, new Vector3 (posX, posY + offsetY, transform.position.z));
		}


		if (Input.GetKeyDown (KeyCode.D)) {
			ind += 1;

		} else if (Input.GetKeyDown (KeyCode.A)) {
			ind -= 1;
		}

		while (ind < 0) {
			ind += persPos.Length;
		}

		ind = ind % persPos.Length;
		persX = persPos[ind];
	}
}
