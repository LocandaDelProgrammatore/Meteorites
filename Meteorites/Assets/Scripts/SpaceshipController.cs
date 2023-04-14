using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour {

	public Action OnSpaceshipDestroyed;
	public Action<int> OnSpaceshipDamaged;
	private SpaceshipMovement spaceshipMovement;
	[SerializeField] private int life;
	[SerializeField] private float timerInvincibility;
	private bool isInvincincible;
	[SerializeField] private Animator animator;
	
	public int Life => life;

	public SpaceshipMovement SpaceshipMovement => spaceshipMovement;

	private void Awake() {
		spaceshipMovement = GetComponent<SpaceshipMovement>();
		
	}
	
	
	private void DecreaseLife(int reduceLife) {
		life -= reduceLife;
		OnSpaceshipDamaged?.Invoke(life);
		isInvincincible = true;
		StartCoroutine(WaitBeforeTurnOffInvincible());
		if (life <= 0) {
			OnSpaceshipDestroyed?.Invoke();
			spaceshipMovement.StopMovement();
		}
	}


	IEnumerator WaitBeforeTurnOffInvincible() {
		
		animator.SetBool("damage",true);
		yield return new WaitForSeconds(timerInvincibility);
		isInvincincible = false;
	}



	private void OnCollisionEnter2D(Collision2D col) {
		if(col.gameObject.CompareTag("Obstacle") && !isInvincincible) {
			var obstacleController = col.gameObject.GetComponent<ObstacleController>();
			DecreaseLife(obstacleController.LifeDamager);
			obstacleController.OnObstacleDeath?.Invoke(obstacleController);
			obstacleController.DestroyElement();
		}
	}
	
}