using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntuacion : MonoBehaviour {
	private float printScore;
	private string datehoy;
	private int variableStart = 0;
	// Use this for initialization
	void Start(){
		//funcion para coger el valor del Score
	}
	// Update is called once per frame
	void Update () {
		if (variableStart == 0){ //debe ejecutarse antes el start de ScorePersistente
			printScore = ScorePersistente.Instance.getPlayerScore ();
			variableStart++;
		}
		printScore += Time.deltaTime;
		ScorePersistente.Instance.setPlayerScore(printScore); //funcion para modificar el Score
		printScore = ScorePersistente.Instance.getPlayerScore ();
		datehoy = System.DateTime.Now.ToString("HH:mm:ss");
	}
	void OnGUI() {
		GUI.Label(new Rect(10, 10, 100, 20), Mathf.FloorToInt(printScore).ToString());
		GUI.Label(new Rect(10, 30, 100, 20), datehoy);
	}
}
