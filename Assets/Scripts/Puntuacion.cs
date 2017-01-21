using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntuacion : MonoBehaviour {
	private int printScore;
	private string datehoy;
	// Use this for initialization
	void Start(){
		printScore = ScorePersistente.Instance.getPlayerScore ();//funcion para coger el valor del Score
		printScore++;
	}
	// Update is called once per frame
	void Update () {
		ScorePersistente.Instance.setPlayerScore(printScore); //funcion para modificar el Score
		printScore = ScorePersistente.Instance.getPlayerScore ();
		datehoy = System.DateTime.Now.ToString("HH:mm:ss");
	}
	void OnGUI() {
		GUI.Label(new Rect(10, 10, 100, 20), printScore.ToString());
		GUI.Label(new Rect(10, 30, 100, 20), datehoy);
	}
}
