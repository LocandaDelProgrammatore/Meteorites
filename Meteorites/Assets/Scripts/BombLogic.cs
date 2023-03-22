using UnityEngine;

public class BombLogic : BulletLogic {

	
	public BombDrop bombDrop;
	private float rangeX;
	private float rangeY;
	

	public void Init(BombDrop drop) {
		damage = drop.damage;
		velocity = drop.velocity;
		lifeTimer = drop.lifeTimer;
		bombDrop = drop;
		timerMovement = drop.timerMovement;
		waitTimer = drop.waitTimer;
		transform.localScale *= drop.sizeBomb;
		
		if (lifeTimer < 0) {
			var plane = FindObjectOfType<PlaneCollider>();
			var planeCollider = plane.GetComponent<Collider>();
			rangeX = planeCollider.bounds.size.x / 2;
			rangeY = planeCollider.bounds.size.y / 2;
			StartCoroutine(MoveCor(CalculateNewPosition(rangeX,rangeY)));
		}
	}
	
	

	public override void DestroyBullet() {
		var position = transform.position;
		bombDrop.DeathBombLogic(position);
		base.DestroyBullet();
	}

	private void OnTriggerEnter2D(Collider2D col) {

		var obstacleController = col.GetComponent<ObstacleController>();
		var bulletLogic = col.GetComponent<BulletLogic>();

		if (obstacleController != null) {
			DestroyBullet();
			return;
		}

		if (bulletLogic != null) {
			if (!bulletLogic.PenetratingEnemy) {
				bulletLogic.DestroyBullet();
			}
			DestroyBullet();
		}
	}

}