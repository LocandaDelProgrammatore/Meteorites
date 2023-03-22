using UnityEngine;

public class SpawnerBombs : MonoBehaviour {

	public const int BombCounter = 5;
	private BombUi bombUi;
	public BombDrop[] bombDrops = new BombDrop[BombCounter];
	private DropManager dropManager;
	private int indexBomb = 0;
	
	private void Awake() {
		
		bombUi = FindObjectOfType<BombUi>();
		bombUi.SetBombRemain(indexBomb+1);
		dropManager = FindObjectOfType<DropManager>();
		dropManager.OnDropRequested += TryAddPower;
	}

	private void TryAddPower(Drop drop) {
		if (drop is BombDrop bombDrop && indexBomb < bombDrops.Length-1) {
			indexBomb ++;
			bombDrops[indexBomb] = bombDrop;
			bombUi.SetBombRemain(indexBomb+1);
		}
	}

	
	
	private void Update() {
		
		if (indexBomb < 0 ) {
			return;
		}

		if (Input.GetMouseButtonDown(1)) {
			Shoot();
		}
	}

	private void Shoot() {
		var bomb = bombDrops[indexBomb];
		bomb.Shoot(transform.position,transform.rotation,transform);
		indexBomb--;
		bombUi.SetBombRemain(indexBomb+1);
	}


}