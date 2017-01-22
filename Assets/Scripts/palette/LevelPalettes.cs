using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelPalettes : MonoBehaviour {
  public float nextPaletteIntervalInSeconds = 2f;
  private float paletteChangeTriggered = float.MaxValue;
  private float paletteChangeToFinish = float.MaxValue;

  public Palette[] dayPalettes;
  public Palette[] nightPalettes;
  public Palette[] bossDayPalettes;
  public Palette[] bossNightPalettes;
  public Palette currentPalette;
  public Palette currentPaletteUnlerped;
  public Palette originPalette;

  // Singleton
  private static LevelPalettes _instance;
  public static LevelPalettes Instance { get; private set; }
  void Start() {
    if (Instance != null && Instance != this) {
      Destroy(gameObject);
    } else {
      Instance = this;
      DontDestroyOnLoad(gameObject);
      paletteSwap();
    }
  }

  void Update() {
    float transitionStep = (Time.time - paletteChangeTriggered) / (paletteChangeToFinish - paletteChangeTriggered);
    currentPalette = LevelPalettes.paletteLerp(originPalette, currentPaletteUnlerped, transitionStep);
  }

  public void paletteSwap() {
    originPalette = currentPalette;
    currentPaletteUnlerped = LevelPalettes.randomNextPalette(currentPaletteUnlerped, this.getCurrentPalettes());
    paletteChangeTriggered = Time.time;
    paletteChangeToFinish = paletteChangeTriggered + nextPaletteIntervalInSeconds;
  }

  public Palette[] getCurrentPalettes() {
    int nowHour = System.DateTime.Now.Hour;
    if (Universal.isNightTime()) {
      return nightPalettes;
    }
    return dayPalettes;
  }

  public Palette[] getCurrentBossPalettes() {
    int nowHour = System.DateTime.Now.Hour;
    if (Universal.isNightTime()) {
      return bossNightPalettes;
    }
    return bossDayPalettes;
  }

  public static Palette paletteLerp(Palette a, Palette b, float t) {
    Palette rval = new Palette();
    rval.backgroundUp = Color.Lerp(a.backgroundUp, b.backgroundUp, t);
    rval.backgroundDown = Color.Lerp(a.backgroundDown, b.backgroundDown, t);
    rval.line = Color.Lerp(a.line, b.line, t);
    rval.platform = Color.Lerp(a.platform, b.platform, t);

    return rval;
  }

  public static Palette randomNextPalette(Palette current, Palette[] selector) {
    int tries = 3;
    Palette next = selector[UnityEngine.Random.Range(0, selector.Length)];
    while (tries > 0 && next.Equals(current)) {
      next = selector[UnityEngine.Random.Range(0, selector.Length)];
      tries--;
    }

    return next;
  }
}
