using UnityEngine;

[CreateAssetMenu(menuName = "DropPower/ShootPower/Tucano", fileName = "Tucano", order = 0)]
public class Tucano : ShootPower {

	public override void Shoot(Vector3 pos,Quaternion rotation, Transform parent) {
		var bullet =  Instantiate(bulletToInstance, pos, rotation,parent);
		var bulletList = bullet.GetComponentsInChildren<BulletMovement>();
		foreach (var bulletMovement in bulletList) {
			bulletMovement.Init(velocity,lifeTimeBullet,lifeDamageBullet);
		}
	}
}