using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoresIndividual : MonoBehaviour {

	public GameObject TablaScoreObject;
	private CargarTablaScore listscore = null;

	Text name;

	// Use this for initialization
	void Start () {

		listscore = TablaScoreObject.GetComponent<CargarTablaScore> ();
		name = GetComponent<Text>();
	}

	// Update is called once per frame
	void Update () {
		name.text = ("REAPARECIENDO EN 5 SEG\n"+listscore.scores[0].player+"\t\t\t\t\t"+listscore.scores[0].score.ToString("F3")+"\n"+
			listscore.scores[1].player+"\t\t\t\t\t"+listscore.scores[1].score.ToString("F3")+"\n"+
			listscore.scores[2].player+"\t\t\t\t\t"+listscore.scores[2].score.ToString("F3")+"\n"+
			listscore.scores[3].player+"\t\t\t\t\t"+listscore.scores[3].score.ToString("F3")+"\n"+
			listscore.scores[4].player+"\t\t\t\t\t"+listscore.scores[4].score.ToString("F3")+"\n"+
			listscore.scores[5].player+"\t\t\t\t\t"+listscore.scores[5].score.ToString("F3")+"\n");
	}
}
