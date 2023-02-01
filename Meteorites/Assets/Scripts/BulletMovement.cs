using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {

	[SerializeField] float velocity = 3f;
	[SerializeField] private float lifeTimer = 1.2f;
	private float currentLifeTimer;
	
	private void Awake() {
		transform.parent = null;
	}

	private void Update() {
		currentLifeTimer += Time.deltaTime;
		
		if (currentLifeTimer < lifeTimer) {
			transform.position += transform.up * velocity * Time.deltaTime;
		}
		else {
			DestroyBullet();
		}
	}


	public void DestroyBullet() => Destroy(gameObject);


}
