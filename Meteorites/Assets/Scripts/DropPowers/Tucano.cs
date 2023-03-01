using UnityEngine;

[CreateAssetMenu(menuName = "DropPower/ShootPower/Tucano", fileName = "Tucano", order = 0)]
public class Tucano : ShootPower {

	public override void Shoot(Vector3 pos,Quaternion rotation, Transform parent) {
		Instantiate(bulletToInstance, pos, rotation,parent);
	}
}