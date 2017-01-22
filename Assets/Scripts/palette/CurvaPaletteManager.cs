using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvaPaletteManager : MonoBehaviour {
	void Update () {
    GetComponent<Renderer>().material.color = LevelPalettes.Instance.currentPalette.line;
	}
}
