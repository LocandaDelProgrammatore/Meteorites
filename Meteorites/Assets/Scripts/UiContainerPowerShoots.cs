using System.Collections.Generic;
using UnityEngine;

public class UiContainerPowerShoots : MonoBehaviour {

	[SerializeField] private List<UiPowerShoot> uiPowerShoots;
	private DropManager dropManager;
	private DroneController droneController;
	private int index;
    
	private void Awake() {
		index = 0;
		dropManager = FindObjectOfType<DropManager>();
		droneController = FindObjectOfType<DroneController>();
		dropManager.OnDropRequested += TryUpdateUi;
		droneController.OnDroneDestroyed += ClearDroneUi;
	}

	private void TryUpdateUi(Drop drop) {
		if (drop is not PowerDrop powerDrop) {
			return;
		}

		if (drop is BombDrop) {
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


	private void ClearDroneUi(DroneDrop droneDrop) {
		
		index--;
		
		for (int i = 0; i < uiPowerShoots.Count; i++) {
			if (uiPowerShoots[i].IsSameType(droneDrop)) {
				switch (i) {
					case 0:
						if (uiPowerShoots[1].DropPower != null) {
							uiPowerShoots[0].Init(uiPowerShoots[1].DropPower);
							uiPowerShoots[1].DeInit();
							return;
						}
						uiPowerShoots[0].DeInit();
						return;
					case 1:
						uiPowerShoots[1].DeInit();
						return;
						
				}
			}
		}
	}

}