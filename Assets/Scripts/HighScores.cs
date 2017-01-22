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
		name.text = (listscore.scores[0].player+"\t\t\t\t\t\t\t\t\t\t\t\t\t\t"+listscore.scores[0].score.ToString("F3")+"\n"+
			listscore.scores[1].player+"\t\t\t\t\t\t\t\t\t\t\t\t\t\t"+listscore.scores[1].score.ToString("F3")+"\n"+
			listscore.scores[2].player+"\t\t\t\t\t\t\t\t\t\t\t\t\t\t"+listscore.scores[2].score.ToString("F3")+"\n"+
			listscore.scores[3].player+"\t\t\t\t\t\t\t\t\t\t\t\t\t\t"+listscore.scores[3].score.ToString("F3")+"\n"+
			listscore.scores[4].player+"\t\t\t\t\t\t\t\t\t\t\t\t\t\t"+listscore.scores[4].score.ToString("F3")+"\n"+
			listscore.scores[5].player+"\t\t\t\t\t\t\t\t\t\t\t\t\t\t"+listscore.scores[5].score.ToString("F3")+"\n");
	}
}
