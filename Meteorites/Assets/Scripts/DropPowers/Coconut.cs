

using UnityEngine;

[CreateAssetMenu(menuName = "DropPower/Bombs/Coconut", fileName = "Coconut", order = 0)]
public class Coconut : BombDrop {

	
	public override void DeathBombLogic(Vector2 pos) {
		var explosionInstantiated = Instantiate(explosionObject, pos, Quaternion.identity);
		var explosionComponent = explosionInstantiated.GetComponent<ExplosionLogic>();
		explosionComponent.Init(sizeExplosion,damage);
	}
}