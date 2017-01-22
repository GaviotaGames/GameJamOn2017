using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoopController : MonoBehaviour {
  private ExtraLives[] players;
  public float respawnSeconds = 5;
  private float deathTime = float.MaxValue;

  void Start () {
	players = FindObjectsOfType<ExtraLives> ();
  }

  void Update () {
	foreach (ExtraLives player in players) {
		if (player.getExtraLives() == 0) {
			deathTime = Time.time;
			player.deactivate();
			player.restartLifeCounter();
		} else if (!isRespawning()) {
			player.reactivate();
		}
	}
  }

  public bool isRespawning () {
    return Time.time > deathTime && Time.time < deathTime + respawnSeconds;
  }

  void OnGUI () {
	int i = 0;
	foreach (ExtraLives player in players) {
		Rect guiPosition = new Rect(10, 700 + 10 * i, 100, 20);
		if (isRespawning()) {
			GUI.Label(guiPosition, "Player " + i + ": You are dead");
		} else {
			GUI.Label(guiPosition, "Lives: " + player.getExtraLives());
		}
	}
  }
}
