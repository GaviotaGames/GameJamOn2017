using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLoopController : MonoBehaviour {
  private ExtraLives player;
  private CargarTablaScore listscore = new CargarTablaScore();
  public GameObject panelblack;
  public GameObject Curvaobject;
  public GameObject TextObject;
  public GameObject SpriteObject;
  private Curva curvaScript;
  public float respawnSeconds = 5;
  private float deathTime = float.MaxValue;
  Text name;

  void Start () {
	name = GetComponent<Text>();
    player = FindObjectOfType<ExtraLives>();
	listscore = GetComponent<CargarTablaScore> ();
	curvaScript = Curvaobject.GetComponent<Curva> ();
  }

  void Update () {
		if (player.getExtraLives () == 0) {
			panelblack.SetActive (true);
			TextObject.SetActive (true);
			SpriteObject.SetActive (true);
			Debug.Log ( ScorePersistente.Instance.getPlayerScore ());
			listscore.guardarScore (ScorePersistente.Instance.getPlayerName() , ScorePersistente.Instance.getPlayerScore ());		
			deathTime = Time.time;
			player.deactivate ();
			player.restartLifeCounter ();
		} else if (!isRespawning ()) {
			panelblack.SetActive (false);
			TextObject.SetActive (false);
			SpriteObject.SetActive (false);
			curvaScript.offsetY = 0;
			ScorePersistente.Instance.setPlayerScore (0f);
			player.reactivate ();
		} else if (isRespawning ()) {
			curvaScript.offsetY += 0.1f;
		}
  }

  public bool isRespawning () {
    return Time.time > deathTime && Time.time < deathTime + respawnSeconds;
  }

  void OnGUI () {
    Rect guiPosition = new Rect(10, 700, 100, 20);
    /*if (isRespawning()) {
      GUI.Label(guiPosition, "You are dead");
    } else {
      GUI.Label(guiPosition, "Lives: " + player.getExtraLives());
    }*/
  }
}
