using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwappingPalettesRandomely : MonoBehaviour {
  public float swapPalettesEverySeconds = 5;
  private float nextSwap = 0;

  void Update () {
	  if (Time.time > nextSwap) {
      LevelPalettes.Instance.paletteSwap();
      nextSwap = Time.time + swapPalettesEverySeconds;
    }	
	}
}
