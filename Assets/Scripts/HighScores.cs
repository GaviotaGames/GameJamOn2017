using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScores : MonoBehaviour {

	private CargarTablaScore listscore = new CargarTablaScore();

	Text name;

	// Use this for initialization
	void Start () {

		listscore = GetComponent<CargarTablaScore> ();
		name = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		name.text = listscore.scores[0].player;
	}
}
