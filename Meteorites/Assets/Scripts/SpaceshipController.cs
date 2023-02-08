using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour {

	public Action OnSpaceshipDestroyed;
	public Action<int> OnSpaceshipDamaged;
	private SpaceshipMovement spaceshipMovement;
	[SerializeField] private int life;

	public int Life => life;

	private void Awake() {
		spaceshipMovement = GetComponent<SpaceshipMovement>();
		
	}
	
	
	private void DecreaseLife(int reduceLife) {
		life -= reduceLife;
		OnSpaceshipDamaged?.Invoke(life);
		if (life <= 0) {
			OnSpaceshipDestroyed?.Invoke();
			spaceshipMovement.StopMovement();
		}
	}
	

	private void OnCollisionEnter2D(Collision2D col) {
		if(col.gameObject.CompareTag("Obstacle")) {
			var obstacleController = col.gameObject.GetComponent<ObstacleController>();
			DecreaseLife(obstacleController.LifeDamager);
		}
	}
	
}