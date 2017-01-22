using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardPaletteManager : MonoBehaviour {
	void Update () {
    foreach(Renderer r in GetComponentsInChildren<Renderer>()) {
      r.material.color = LevelPalettes.Instance.currentPalette.platform;
    }  
  }
}
