using System;
using UnityEngine;

public enum Direction {
	Nord,
	Sud,
	Est,
	Ovest
}

public class FloorCollider : MonoBehaviour {

	public Action<Direction> OnPlayerCollide;
	[SerializeField] Direction direction;

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.GetComponent<SpaceshipController>()) {
			OnPlayerCollide?.Invoke(direction);
		}
	}
}