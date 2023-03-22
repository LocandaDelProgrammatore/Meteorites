using UnityEngine;


public abstract class BombDrop : PowerDrop {

	public GameObject bombToInstance;
	public GameObject explosionObject;
	public float damage;
	public float velocity;
	public float sizeExplosion;
	public float lifeTimer;
	public float timerMovement;
	public float waitTimer;
	public float sizeBomb;

	public abstract void DeathBombLogic(Vector2 pos);
	
	public override void Shoot(Vector3 pos, Quaternion rotation, Transform parent) {
		var objectBomb =  Instantiate(bombToInstance, pos, rotation, parent);
		objectBomb.GetComponent<BombLogic>().Init(this);
	}

}












