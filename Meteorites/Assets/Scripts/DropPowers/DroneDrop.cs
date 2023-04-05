using UnityEngine;

public abstract class DroneDrop : PowerDrop {

	public int life;
	public Sprite droneSprite;
	public ShootPower shootPower;

	public override void Shoot(Vector3 pos, Quaternion rotation, Transform parent) {
		shootPower.Shoot(pos,rotation,parent);
	}

}