using UnityEngine;

public class DropComponent : MonoBehaviour {
	
	[SerializeField] SpriteRenderer spriteRenderer;
	public Drop drop;
	private DropManager dropManager;	


	public void Init(Drop d) {
		drop = d;
		dropManager = FindObjectOfType<DropManager>();
		spriteRenderer.sprite = drop.dropSprite;
	}

	private void OnCollisionEnter2D(Collision2D col) {
		
		if (col.gameObject.GetComponent<SpaceshipController>()) {
			dropManager.RequestDrop(drop);
			Destroy(gameObject);
		}
	}
}