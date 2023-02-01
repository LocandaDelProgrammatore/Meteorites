using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {

	[SerializeField] private GameObject explosion;
	
	private void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.GetComponent<BulletMovement>()) {
			col.gameObject.GetComponent<BulletMovement>().DestroyBullet();
			Instantiate(explosion, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
}
