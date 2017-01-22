using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundaries : MonoBehaviour
{
	void OnTriggerExit(Collider other)
	{
    ExtraLives collided = other.GetComponent<ExtraLives>();

    if (collided != null) {
      collided.takeALife();
    }
	}
}
