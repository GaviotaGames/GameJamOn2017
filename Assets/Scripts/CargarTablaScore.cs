using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargarTablaScore : MonoBehaviour {
	public List <PlayerScore> scores = new List <PlayerScore>();
	// Use this for initialization
	void Start () {
		for (var i = 0; i < 10; i++)
		{
			if(PlayerPrefs.GetString ("Name" + i) == ""){
				PlayerPrefs.SetFloat("Score"+0, 720);
				PlayerPrefs.SetString("Name"+0, "GOD");
				PlayerPrefs.SetFloat("Score"+1, 666);
				PlayerPrefs.SetString("Name"+1, "STN");
				PlayerPrefs.SetFloat("Score"+2, 500);
				PlayerPrefs.SetString("Name"+2, "ASS");
				PlayerPrefs.SetFloat("Score"+3, 250);
				PlayerPrefs.SetString("Name"+3, "SIR");
				PlayerPrefs.SetFloat("Score"+4, 100);
				PlayerPrefs.SetString("Name"+4, "ALF");
				PlayerPrefs.SetFloat("Score"+5, 75);
				PlayerPrefs.SetString("Name"+5, "1AI");
				PlayerPrefs.SetFloat("Score"+6, 50);
				PlayerPrefs.SetString("Name"+6, "Alf");
				PlayerPrefs.SetFloat("Score"+7, 40);
				PlayerPrefs.SetString("Name"+7, "Luigi");
				PlayerPrefs.SetFloat("Score"+8, 30);
				PlayerPrefs.SetString("Name"+8, "Mario");
				PlayerPrefs.SetFloat("Score"+9, 1);
				PlayerPrefs.SetString("Name"+9, "Unai");
			}
			scores.Add ( new PlayerScore(PlayerPrefs.GetString ("Name" + i),PlayerPrefs.GetFloat("Score"+i)));
		}
	}
	/*
	void OnGUI() {
		for (var i = 0; i < 10; i++) {
			GUI.Label (new Rect (70, 10*i+10, 100, 20), (i+1).ToString() +"->     "+scores[i].score.ToString());
			GUI.Label (new Rect (140, 10*i+10, 100, 20), scores[i].player);
		}
	}*/
	public void guardarScore(string nombreplayer,float scorefinal){
		scores.Add ( new PlayerScore(nombreplayer,scorefinal));
		scores.Sort (PlayerScore.compararScores);
		for (var i=0;i<10;i++)
		{
			PlayerPrefs.SetFloat("Score"+i, scores[i].score);
			PlayerPrefs.SetString("Name"+i, scores[i].player);
		}
		PlayerPrefs.Save ();
	}
	// Update is called once per frame
	/*void Update () {
		
	}*/

}
