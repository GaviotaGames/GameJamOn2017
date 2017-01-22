using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLoopController : MonoBehaviour
{
	private ExtraLives[] players;
	private CargarTablaScore listscore = new CargarTablaScore ();
	private float printScore = 0;
	private int variableStart = 0;
	public GameObject panelblack;
	public GameObject Curvaobject;
	public GameObject TextObject;
	public GameObject SpriteObject;
	private Curva curvaScript;
	public float respawnSeconds = 5;
	private float deathTime = float.MaxValue;
	Text name;

	void Start ()
	{
		players = FindObjectsOfType<ExtraLives> ();
	}

	void Update ()
	{
		name = GetComponent<Text> ();
		listscore = GetComponent<CargarTablaScore> ();
		curvaScript = Curvaobject.GetComponent<Curva> ();
		foreach (ExtraLives player in players) {
			if (player.getExtraLives () == 0) {
				panelblack.SetActive (true);
				TextObject.SetActive (true);
				SpriteObject.SetActive (true);
				print (ScorePersistente.Instance.getPlayerName ());
				print (ScorePersistente.Instance.getPlayerScore ().ToString ());
				listscore.guardarScore (ScorePersistente.Instance.getPlayerName (), ScorePersistente.Instance.getPlayerScore ());		
				deathTime = Time.time;
				player.deactivate ();
				player.restartLifeCounter ();
			} else if (!isRespawning ()) {
				panelblack.SetActive (false);
				TextObject.SetActive (false);
				SpriteObject.SetActive (false);
				curvaScript.offsetY = 0;
				player.reactivate ();
			} else if (isRespawning ()) {
				curvaScript.offsetY += 0.1f;
				ScorePersistente.Instance.setPlayerScore (0f);
				printScore = 0f;
			}
		}
	}

	public bool isRespawning ()
	{
		return Time.time > deathTime && Time.time < deathTime + respawnSeconds;
	}

}

