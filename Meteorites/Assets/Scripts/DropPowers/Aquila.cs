using UnityEngine;

[CreateAssetMenu(menuName = "DropPower/ShootPower/Aquila", fileName = "Aquila", order = 0)]
public class Aquila : ShootPower {

	public override void Shoot(Vector3 pos,Quaternion rotation, Transform parent) {
		var bullet =  Instantiate(bulletToInstance, pos, rotation,parent);
		var bulletMovementComponent = bullet.GetComponent<BulletLogic>();
		bulletMovementComponent.Init(velocity,lifeTimeBullet,lifeDamageBullet, true);
	}
}