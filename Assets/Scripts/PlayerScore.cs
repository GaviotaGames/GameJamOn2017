using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerScore {
	public string player;
	public float score;
	public PlayerScore(string player, float score){
		this.player = player;
		this.score = score;
	} 
	public static int compararScores (PlayerScore o, PlayerScore y) {
		if (o.score > y.score) {
			return -1;
		}
		if (o.score < y.score) {
			return 1;
		}
		return 0;
	}
}
