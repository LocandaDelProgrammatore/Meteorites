using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleController : MonoBehaviour {

	public Action OnObstacleDeath;
	public Action<Vector3,float> OnObstacleRequestSpawn;

	[SerializeField] private GameObject explosion;
	[SerializeField] private int lifeDamager;
	[SerializeField] private Vector2 minMaxSize = new Vector2(0.5f, 5);
	[SerializeField] private float minSizeForSpawnNewAsteroid;
	[SerializeField] private float minSizeForSpawnDrop = 3;
	private DropSpawner dropSpawner;
	private bool isRequestSpawnOtherObstacle;
	private float sizeRandom;



	public int LifeDamager => lifeDamager;
	

	public void Init(bool isAfterExplosion,float parentScale = 0) {
		if (isAfterExplosion) {
			transform.localScale = new Vector3(parentScale/2, parentScale/2, minMaxSize.x);
			return;
		}
		dropSpawner = FindObjectOfType<DropSpawner>();
		sizeRandom = Random.Range(minMaxSize.x, minMaxSize.y);
		isRequestSpawnOtherObstacle = sizeRandom >= minSizeForSpawnNewAsteroid;
		transform.localScale = new Vector3(sizeRandom, sizeRandom, sizeRandom);
	}

	private void OnTriggerEnter2D(Collider2D col) {
		var bulletComponent = col.gameObject.GetComponent<BulletLogic>();
		var explosionComponent = col.gameObject.GetComponent<ExplosionLogic>();
		
		if (bulletComponent != null || explosionComponent !=null) {
			
			OnObstacleDeath?.Invoke();
			
			if (isRequestSpawnOtherObstacle) {
				OnObstacleRequestSpawn?.Invoke(transform.position,transform.localScale.x);
			}
			
			if (sizeRandom >= minSizeForSpawnDrop) {
				dropSpawner.Spawn(DropDatabase.Instance.GetDrop(sizeRandom), transform.position);
			}
			
			if (bulletComponent!=null &&  !bulletComponent.PenetratingEnemy) {
				bulletComponent.DestroyBullet();
			}
			
			Instantiate(explosion, transform.position, Quaternion.identity);

			Destroy(gameObject);
		}
	}
}