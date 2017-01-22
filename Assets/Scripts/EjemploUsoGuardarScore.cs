using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjemploUsoGuardarScore : MonoBehaviour {
	private CargarTablaScore listscore = new CargarTablaScore();
	// Use this for initialization
	void Start () {
		listscore = GetComponent<CargarTablaScore> ();
	}


	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.G)){
			listscore.guardarScore ("Yisus", 60f);
		}
	}

}
