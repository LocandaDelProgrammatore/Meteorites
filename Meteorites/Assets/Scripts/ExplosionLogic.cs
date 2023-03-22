using System;
using System.Collections;
using UnityEngine;

public class ExplosionLogic : MonoBehaviour {

	public CircleCollider2D explosionCollider;
	public float timerDestroy;
	public float damage;
	


	public void Init(float size,float d) {
		explosionCollider.enabled = true;
		explosionCollider.radius = size;
		damage = d;
	}

	private void Awake() {
		
		StartCoroutine(WaitBeforeDestroy());
	}

	private IEnumerator WaitBeforeDestroy() {
		yield return new WaitForSeconds(timerDestroy);
		Destroy(gameObject);
	}
}