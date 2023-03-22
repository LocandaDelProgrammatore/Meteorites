using TMPro;
using UnityEngine;

public class BombUi : MonoBehaviour {

	public TMP_Text bombText;


	public void SetBombRemain(int number) => bombText.text = number.ToString();
}