using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class BulletLogic : MonoBehaviour {

	public float velocity = 3f;
	public float lifeTimer = 1.2f;
	public float damage = 2;
	private float currentLifeTimer;
	private bool penetratingEnemy;
	private float rangeX;
	private float rangeY;
	public float timerMovement = 1;
	public float waitTimer;

	public bool PenetratingEnemy => penetratingEnemy;

	private void Awake() {
		transform.parent = null;
	}

	public void Init(float vel, float lifeT,float d,bool penetrating = false) {
		velocity = vel;
		lifeTimer = lifeT;
		damage = d;
		penetratingEnemy = penetrating;
		if (lifeTimer < 0) {
			var plane = FindObjectOfType<PlaneCollider>();
			var planeCollider = plane.GetComponent<Collider>();
			rangeX = planeCollider.bounds.size.x / 2;
			rangeY = planeCollider.bounds.size.y / 2;
			StartCoroutine(MoveCor(CalculateNewPosition(rangeX,rangeY)));
		}
	}

	
	

	private void Update() {
		if (lifeTimer > 0) {
			Move();
		}
	}

	public void Move() {
		
			currentLifeTimer += Time.deltaTime;
			
			if (currentLifeTimer < lifeTimer) {
				transform.position += transform.up * velocity * Time.deltaTime;
			}
			else {
				DestroyBullet();
			}


	}

	public Vector2 CalculateNewPosition(float rangeX, float rangeY) {
		return new Vector2(Random.Range(-rangeX,rangeX),Random.Range(-rangeY,rangeY));
	}

	public IEnumerator MoveCor(Vector2 newPos) {
		var initPos = transform.position;
		float t = 0f;
		while (t < timerMovement) {
			transform.position = Vector3.Lerp(initPos, newPos, t / timerMovement);
			t += Time.deltaTime;
			yield return null;
		}
		transform.position = newPos;
		yield return new WaitForSeconds(waitTimer);
		StartCoroutine(MoveCor(CalculateNewPosition(rangeX,rangeY)));
	}





	public virtual void DestroyBullet() => Destroy(gameObject);


}