using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public float aleatoriedad = 0f;

	public GameObject[] hazardArray;

	public int numSelectors = 5;

	int numero = 0;

	int avance = 6;
	float posX = 0;


	void Start ()
	{
		posX = spawnValues.x;
		StartCoroutine(SpawnWaves ());
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);

		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				posX = posX + avance;
				numero = Random.Range (0, hazardArray.Length);

				//Debug.Log ("numero: " + numero);

				hazard = hazardArray [numero];

				Vector3 spawnPosition = new Vector3 (posX, spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = new Quaternion ();
				GameObject newHazard = Instantiate (hazard, spawnPosition, spawnRotation);
        		newHazard.AddComponent(typeof(HazardPaletteManager));
				yield return new WaitForSeconds (spawnWait);
			}

			yield return new WaitForSeconds (waveWait);
		}
	}

}
