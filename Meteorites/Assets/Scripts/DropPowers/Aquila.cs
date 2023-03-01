using UnityEngine;

[CreateAssetMenu(menuName = "DropPower/ShootPower/Aquila", fileName = "Aquila", order = 0)]
public class Aquila : ShootPower {

	public override void Shoot(Vector3 pos,Quaternion rotation, Transform parent) {
		Instantiate(bulletToInstance, pos, rotation,parent);
	}
}