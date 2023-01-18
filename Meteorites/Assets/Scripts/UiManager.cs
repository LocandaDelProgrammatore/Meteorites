using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour {

	[SerializeField] private TMP_Text gameOverText;
	[SerializeField] private Button gameOverButton;

	private void Awake() {
		gameOverText.gameObject.SetActive(false);
		gameOverButton.onClick.AddListener(RestartGame);
		gameOverButton.gameObject.SetActive(false);
	}

	private void RestartGame() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void ActiveGameOverUiElements() {
		gameOverText.gameObject.SetActive(true);
		gameOverButton.gameObject.SetActive(true);
	}
}