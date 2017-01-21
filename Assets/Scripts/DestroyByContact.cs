using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
	void OnTriggerEnter(Collider other) {
    ExtraLives collided = other.GetComponent<ExtraLives>();

    if (collided != null) {
      collided.takeALife();
    }
  }
}
