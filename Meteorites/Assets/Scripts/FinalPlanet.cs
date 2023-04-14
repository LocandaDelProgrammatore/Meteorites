using System;
using UnityEngine;

public class FinalPlanet : MonoBehaviour {

	public Action OnFinishGame;
	
	private void OnCollisionEnter2D(Collision2D col) {
		
		if (col.gameObject.GetComponent<SpaceshipController>()) {
			OnFinishGame?.Invoke();
		}
	}
}