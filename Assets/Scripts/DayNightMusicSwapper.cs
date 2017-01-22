using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightMusicSwapper : MonoBehaviour {
  public AudioClip dayClip = null;
  public AudioClip nightClip = null;
  private AudioSource source = null;

	void Start () {
    source = GetComponent<AudioSource>();

    if (Universal.isNightTime()) {
      source.clip = nightClip;
    } else {
      source.clip = dayClip;
    }
    source.Play();
	}
}
