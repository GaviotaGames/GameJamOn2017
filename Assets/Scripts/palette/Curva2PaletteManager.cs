using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curva2PaletteManager : MonoBehaviour {
	void Update () {
		GetComponent<Renderer>().material.color = LevelPalettes.Instance.currentPalette.platform;
	}
}
