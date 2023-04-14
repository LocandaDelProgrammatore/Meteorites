using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour {

	[SerializeField] private TMP_Text gameOverText;
	[SerializeField] private TMP_Text winText;
	[SerializeField] private Button restartButton;

	private void Awake() {
		gameOverText.gameObject.SetActive(false);
		winText.gameObject.SetActive(false);
		restartButton.onClick.AddListener(RestartGame);
		restartButton.gameObject.SetActive(false);
	}

	private void RestartGame() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void ActiveGameOverUiElements() {
		gameOverText.gameObject.SetActive(true);
		restartButton.gameObject.SetActive(true);
	}


	public void ActiveWinUiElement() {
		
		winText.gameObject.SetActive(true);
		restartButton.gameObject.SetActive(true);
	}
}