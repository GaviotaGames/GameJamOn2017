using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoopController : MonoBehaviour {
  private ExtraLives player;
  public float respawnSeconds = 5;
  private float deathTime = float.MaxValue;

  void Start () {
    player = FindObjectOfType<ExtraLives>();
  }

  void Update () {
    if (player.getExtraLives() == 0) {
      deathTime = Time.time;
      player.deactivate();
      player.restartLifeCounter();
    } else if (!isRespawning()) {
      player.reactivate();
    }
  }

  public bool isRespawning () {
    return Time.time > deathTime && Time.time < deathTime + respawnSeconds;
  }

  void OnGUI () {
    Rect guiPosition = new Rect(10, 700, 100, 20);
    if (isRespawning()) {
      GUI.Label(guiPosition, "You are dead");
    } else {
      GUI.Label(guiPosition, "Lives: " + player.getExtraLives());
    }
  }
}
