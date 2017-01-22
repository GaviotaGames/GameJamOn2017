using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicEffects : MonoBehaviour {
  public Curva curva = null;

	void Update () {
    GetComponent<AudioSource>().pitch = Mathf.Lerp(0.8f, 1.2f, (curva.longitude - curva.longitudeMin) / (curva.longitudeMax - curva.longitudeMin));
    GetComponent<AudioSource>().volume = Mathf.Lerp(0.8f, 1, (curva.amplitude - curva.amplitudeMin) / (curva.amplitudeMax - curva.amplitudeMin));
    GetComponent<AudioLowPassFilter>().cutoffFrequency = Mathf.Lerp(800, 1200, (curva.amplitude - curva.amplitudeMin) / (curva.amplitudeMax - curva.amplitudeMin));
  }
}
