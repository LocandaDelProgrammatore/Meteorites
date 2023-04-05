using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour {

	[SerializeField] private Image healthBarImage;
	[SerializeField] private float timerReducerHealth = 0.5f;
	[SerializeField] private bool isForDrone;
	private SpaceshipController controller;
	private DroneController droneController;
	private int initialLife;
	
	
	
	private void Awake() {
		if (isForDrone) {
			droneController = FindObjectOfType<DroneController>();
			droneController.OnDroneDamaged += UpdateHealthBar;
			initialLife = droneController.currentLife;
			gameObject.SetActive(false);
		}
		else {
			controller = FindObjectOfType<SpaceshipController>();
			controller.OnSpaceshipDamaged += UpdateHealthBar;
			initialLife = controller.Life;
		}
	}


	public void InitHealthBar(int life) {
		initialLife = life;
		healthBarImage.fillAmount = 1;
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


