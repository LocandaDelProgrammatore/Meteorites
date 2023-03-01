using UnityEngine;

[CreateAssetMenu(menuName = "DropPower/ShootPower/Colibri", fileName = "Colibri", order = 0)]
public class Colibri : ShootPower {

	
	public override void Shoot(Vector3 pos,Quaternion rotation, Transform parent) {
		var bullet = Instantiate(bulletToInstance, pos, rotation,parent);
		var bulletMovementComponent = bullet.GetComponent<BulletMovement>();
		bulletMovementComponent.Init(velocity,lifeTimeBullet,lifeDamageBullet);
	}
	
	

}