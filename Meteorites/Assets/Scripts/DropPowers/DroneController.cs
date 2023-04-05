using System;
using UnityEngine;

public class DroneController : MonoBehaviour {

	public Action<int> OnDroneDamaged;
	public Action<DroneDrop> OnDroneDestroyed;
	private DroneDrop drop;
	public int currentLife;
	public float timerShoot;
	public SpriteRenderer spriteDrone;
	private DropManager dropManager;
	private float currentTimerWait;
	public Transform shootTransform;
	public HealthBarController healthBarController;
	private Collider2D droneCollder;
	
	private void Awake() {
		dropManager = FindObjectOfType<DropManager>();
		droneCollder = GetComponent<Collider2D>();
		dropManager.OnDropRequested += TryAddDrone;
		droneCollder.enabled = false;
	}

	private void TryAddDrone(Drop powerDrop) {

		if (powerDrop is DroneDrop dropPower) {
			drop = dropPower;
			currentLife = drop.life;
			timerShoot = drop.shootPower.waitTimer;
			spriteDrone.sprite = drop.droneSprite;
			currentTimerWait = 0;
			healthBarController.gameObject.SetActive(true);
			healthBarController.InitHealthBar(currentLife);
			droneCollder.enabled = true;
		}
	}

	private void Update() {
		if (drop != null) {
			currentTimerWait += Time.deltaTime;
			if (currentTimerWait >= timerShoot) {
				drop.Shoot(shootTransform.position,shootTransform.rotation,shootTransform);
				currentTimerWait = 0;
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D other) {

		ObstacleController obstacleController = other.gameObject.GetComponent<ObstacleController>();
		
		if (obstacleController != null ) {
			currentLife -= obstacleController.LifeDamager;
			OnDroneDamaged?.Invoke(currentLife);
			if (currentLife <= 0) {
				DestroyObject();
			}
		}
		
	}

	void DestroyObject() {
		OnDroneDestroyed?.Invoke(drop);
		droneCollder.enabled = false;	
		spriteDrone.sprite = null;
		drop = null;
		healthBarController.gameObject.SetActive(false);
	}

}