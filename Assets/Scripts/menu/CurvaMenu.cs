using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CurvaMenu : MonoBehaviour {

	public float amplitude = 1f;
	public float longitude = 1f;
	public float separacion = 1f;
	public float speed = 2f;
	public float finalSpeed = 2f;
	public float offsetY = 0f;
	public float[] persPos;
	public float persX;
	public GameObject canvasscore;
	public GameObject canvascredits;

	public GameObject singlePlayer;
	public GameObject multiPlayer1;
	public GameObject multiPlayer2;
	public GameObject credits;
	public GameObject scores;
	public GameObject quit;

	private float posX = 0f;
	private float posY = 0f;
	private LineRenderer lineRend = null;
	private int ind = 0;



	// Use this for initialization
	void Start () {
		lineRend = GetComponent <LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

		finalSpeed = speed;
		for (int i = 0; i < lineRend.numPositions; i++) {
			posX = transform.position.x + separacion * i;
			posY = (Mathf.Sin (finalSpeed * Time.time + posX * longitude)) * amplitude;
			lineRend.SetPosition (i, new Vector3 (posX, posY + offsetY, transform.position.z));
		}

	
		if (Input.GetKeyDown(KeyCode.D)) {
				ind += 1;
		} else if (Input.GetKeyDown(KeyCode.A)) {
				ind -= 1;
			}
			


		while (ind < 0) {
			ind += persPos.Length;
		}

		ind = ind % persPos.Length;
		persX = persPos[ind];

		if (ind == 3) {
			canvasscore.SetActive (true);
		} else {
			canvasscore.SetActive (false);
		}

		if (ind == 2) {
			canvascredits.SetActive (true);
		} else {
			canvascredits.SetActive (false);
		}
		UserControlls ();
		ChangeMaterials ();
	}
	void UserControlls(){
		if ((ind == 0) && (Input.GetButtonDown("Fire1")))
			{
				SceneManager.LoadScene("SinglePlayer");
			}
		if ((ind == 1) && (Input.GetButtonDown("Fire1")))
			{
				SceneManager.LoadScene("MultiPlayer");
			}
		if ((ind == 4) && (Input.GetButtonDown("Fire1")) || (Input.GetKeyDown(KeyCode.Escape)))
		{
			Application.Quit();
		}
	}
	void ChangeMaterials()
	{
		if (ind == 0) {
			Renderer rend = singlePlayer.GetComponent<Renderer> ();
			rend.material.color = Color.white;
		} else {
			Renderer rend = singlePlayer.GetComponent<Renderer> ();
			rend.material.color = Color.grey;
		}

		if (ind == 1) {
			Renderer rend = multiPlayer1.GetComponent<Renderer> ();
			rend.material.color = Color.white;
			Renderer rend2 = multiPlayer2.GetComponent<Renderer> ();
			rend2.material.color = Color.white;
		} else {
			Renderer rend = multiPlayer1.GetComponent<Renderer> ();
			rend.material.color = Color.grey;
			Renderer rend2 = multiPlayer2.GetComponent<Renderer> ();
			rend2.material.color = Color.grey;
		}

		if (ind == 2) {
			Renderer rend = credits.GetComponent<Renderer> ();
			rend.material.color = Color.yellow;
		} else {
			Renderer rend = credits.GetComponent<Renderer> ();
			rend.material.color = Color.grey;
		}
			if (ind == 3) {
			Renderer rend = scores.GetComponent<Renderer> ();
				rend.material.color = Color.white;
			} else {
			Renderer rend = scores.GetComponent<Renderer> ();
				rend.material.color = Color.grey;
			}
		if (ind == 4) {
			Renderer rend = quit.GetComponent<Renderer> ();
			rend.material.color = Color.white;
		} else {
			Renderer rend = quit.GetComponent<Renderer> ();
			rend.material.color = Color.grey;
		}

	}
}
