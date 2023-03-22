using UnityEngine;

[CreateAssetMenu(menuName = "DropPower/Bombs/Grape", fileName = "Grape", order = 0)]
public class Grape : BombDrop {

	
	public BombDrop bombDrop;
	public int numberOfBombs;
	

	public override void DeathBombLogic(Vector2 pos) {
		for (int i = 0; i < numberOfBombs; i++) {
			var objectBomb = Instantiate(bombToInstance, pos, Quaternion.identity);
			objectBomb.transform.Rotate(0,0,90/(i+1));
			objectBomb.GetComponent<BombLogic>().Init(bombDrop);
		}
	}
}