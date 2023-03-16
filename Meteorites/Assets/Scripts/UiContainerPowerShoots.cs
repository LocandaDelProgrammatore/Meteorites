using System.Collections.Generic;
using UnityEngine;

public class UiContainerPowerShoots : MonoBehaviour {

	[SerializeField] private List<UiPowerShoot> uiPowerShoots;
	private DropManager dropManager;
	private int index;
    
	private void Awake() {
		index = 0;
		dropManager = FindObjectOfType<DropManager>();
		dropManager.OnDropRequested += TryUpdateUi;
	}

	private void TryUpdateUi(Drop drop) {
		if (drop is not PowerDrop powerDrop) {
			return;
		}

		foreach (var uiPowerShoot in uiPowerShoots) {
			if (uiPowerShoot.IsSameType(powerDrop)) {
				uiPowerShoot.Init(powerDrop);
				return;
			}
		}
		
		uiPowerShoots[index].Init(powerDrop);
		index++;

	}

}