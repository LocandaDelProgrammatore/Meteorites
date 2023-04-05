using System.Collections;
using UnityEngine;

public class DropComponent : MonoBehaviour {
	
	[SerializeField] SpriteRenderer spriteRenderer;
	public Drop drop;
	private DropManager dropManager;
	[SerializeField] private float timerFade = 1;
	


	public void Init(Drop d) {
		drop = d;
		dropManager = FindObjectOfType<DropManager>();
		spriteRenderer.sprite = drop.dropSprite;
		StartCoroutine(WaitBeforeDestroy());
	}


	IEnumerator WaitBeforeDestroy() {
		float alphaValue = spriteRenderer.color.a;
		float t = 0;
		while (t < timerFade) {
			var currentValue = Mathf.Lerp(alphaValue, 0, t / timerFade);
			Color color = spriteRenderer.color;
			color.a = currentValue;
			spriteRenderer.color = color;
			t += Time.deltaTime;
			yield return null;
		}
		
		Destroy(gameObject);
	}

	private void OnCollisionEnter2D(Collision2D col) {
		
		if (col.gameObject.GetComponent<SpaceshipController>()) {
			dropManager.RequestDrop(drop);
			Destroy(gameObject);
		}
	}
}