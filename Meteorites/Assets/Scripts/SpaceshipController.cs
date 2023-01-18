using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour {

	public Action OnSpaceshipDestroyed;
	private SpaceshipMovement spaceshipMovement;

	private void Awake() {
		spaceshipMovement = GetComponent<SpaceshipMovement>();
	}

	private void OnCollisionEnter2D(Collision2D col) {
		if(col.gameObject.CompareTag("Obstacle"))
		{
			spaceshipMovement.StopMovement();
			OnSpaceshipDestroyed?.Invoke();
		}
	}

}
