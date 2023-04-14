using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	
	private SpaceshipController spaceshipController;
	private UiManager uiManager;

	private void Awake() {
		spaceshipController = FindObjectOfType<SpaceshipController>();
		uiManager = FindObjectOfType<UiManager>();
		spaceshipController.OnSpaceshipDestroyed += uiManager.ActiveGameOverUiElements;

	}


	public void AddEventWinGame(FloorManager floorManager) {
		floorManager.finalPlanet.OnFinishGame += uiManager.ActiveWinUiElement;
	}



}