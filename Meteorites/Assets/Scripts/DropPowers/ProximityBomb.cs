using UnityEngine;

[CreateAssetMenu(menuName = "DropPower/Bombs/Proximity", fileName = "ProximityBomb", order = 0)]
public class ProximityBomb : BombDrop {

	public override void DeathBombLogic(Vector2 pos) {
		var explosionInstantiated = Instantiate(explosionObject, pos, Quaternion.identity);
		var explosionComponent = explosionInstantiated.GetComponent<ExplosionLogic>();
		explosionComponent.Init(sizeExplosion,damage);
	}
}