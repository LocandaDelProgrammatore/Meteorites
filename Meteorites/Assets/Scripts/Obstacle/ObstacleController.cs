using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {

	[SerializeField] private GameObject explosion;
	public Action OnObstacleDeath;
	
	
	
	private void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.GetComponent<BulletMovement>()) {
			OnObstacleDeath?.Invoke();
			col.gameObject.GetComponent<BulletMovement>().DestroyBullet();
			Instantiate(explosion, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
}
