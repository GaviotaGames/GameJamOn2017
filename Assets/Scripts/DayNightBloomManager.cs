using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class DayNightBloomManager : MonoBehaviour {
	void Update () {
    if (Universal.isNightTime()) {
      GetComponent<Bloom>().bloomIntensity = 0;
    }
	}
}
