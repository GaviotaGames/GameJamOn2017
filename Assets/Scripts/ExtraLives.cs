using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLives : MonoBehaviour {
  public int startingLives = 3;
  private int extraLives = 3;

  public int takeALife() {
    if (extraLives > 0) {
      extraLives--;
    }

    return extraLives;
  }

  public void Update () {
    for (int i = 0; i < transform.childCount; i++) {
      transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;
    }
    for (int i = 0; i < (extraLives - 1); i++) {
      transform.GetChild(i).GetComponent<MeshRenderer>().enabled = GetComponent<MeshRenderer>().enabled;
    }
  }

  public int getExtraLives() {
    return extraLives;
  }

  public int restartLifeCounter() {
    extraLives = startingLives;
    return extraLives;
  }

  public void deactivate() {
    setActivationState(false);
  }

  public void reactivate() {
    setActivationState(true);
  }

  private void setActivationState(bool active) {
    GetComponent<MeshRenderer>().enabled = active;
    GetComponent<Collider>().enabled = active;
  }
}
