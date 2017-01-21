using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingPaletteManager : MonoBehaviour {
	void Update () {
    Palette currentPalette = LevelPalettes.Instance.currentPalette;
    if (RenderSettings.skybox.HasProperty("_colorUp") && RenderSettings.skybox.HasProperty("_colorDown")) {
      RenderSettings.skybox.SetColor("_colorUp", currentPalette.backgroundUp);
      RenderSettings.skybox.SetColor("_colorDown", currentPalette.backgroundDown);
    } else {
      Debug.LogWarning("Skybox shader doesn't have _colorUp and _colorDown properties: " + RenderSettings.skybox.ToString());
    }
	}
}
