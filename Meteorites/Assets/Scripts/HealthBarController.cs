using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour {

	[SerializeField] private Image healthBarImage;
	[SerializeField] private float timerReducerHealth = 0.5f;
	private SpaceshipController controller;
	private int initialLife;
	
	
	
	private void Awake() {
		controller = FindObjectOfType<SpaceshipController>();
		controller.OnSpaceshipDamaged += UpdateHealthBar;
		initialLife = controller.Life;
	}

	private void UpdateHealthBar(int currentLife) {
		//currentLife = Mathf.Clamp(currentLife, 0, initialLife);
		float normalizedLife = Mathf.InverseLerp(0, initialLife, currentLife);
		StopAllCoroutines();
		StartCoroutine(UpdateLifeCor(normalizedLife));
	}


	IEnumerator UpdateLifeCor(float life) {
		float t = 0;
		float initialFillAmount = healthBarImage.fillAmount;
		while (t<timerReducerHealth) {
			healthBarImage.fillAmount = Mathf.Lerp(initialFillAmount, life, t / timerReducerHealth);
			t += Time.deltaTime;
			yield return null;
		}
		healthBarImage.fillAmount = life;
	}
}