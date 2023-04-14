using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	[SerializeField] private FloorGenerator floorGenerator;
	[SerializeField] private ObstacleSpawner obstacleSpawner;
	[SerializeField] private SpaceshipController spaceshipController;
	[SerializeField] FloorManager currentFloor;
	[SerializeField] private float timerMovement;
	[SerializeField] private float outOfBoundsTimer;
	private Camera mainCamera;

	private List<FloorManager> floorManagers = new List<FloorManager>();

	private void Awake() {
		floorGenerator.OnFinishIstanciate += UpdateList;
		mainCamera = Camera.main;
	}


	private void UpdateList(List<FloorManager> floors) {
		floorManagers.AddRange(floors);
		currentFloor = floorManagers[0];
		currentFloor.ActiveFloorCollider();
		obstacleSpawner.InitSpawn(currentFloor.GetComponent<Collider>());
		foreach (var floorManager in floorManagers) {
			floorManager.OnChangeFloorRequested += UpdateCurrentFloor;
			floorManager.OnBoundReached += AddForceToSpaceShip;
		}
	}


	private void UpdateCurrentFloor(int x,int y) {
		currentFloor.TurnoffCollider();
		currentFloor = floorGenerator.GetFloorBasedOnIndex(x, y);
		StartCoroutine(MoveCamera());
	}


	private void AddForceToSpaceShip() {
		
		StartCoroutine(WaitBeforeActiveSpaceShipMovement());

	}

	IEnumerator WaitBeforeActiveSpaceShipMovement() {
		spaceshipController.SpaceshipMovement.StopMovement();
		var posSpaceship = spaceshipController.transform.position;
		var currentPosFloor = currentFloor.transform.position;
		float finalX = (posSpaceship.x + currentPosFloor.x) / 2;
		float finalY = (posSpaceship.y + currentPosFloor.y) / 2;
		var finalPosSpaceship = new Vector3(finalX, finalY);
		float t = 0f;

		while (t < outOfBoundsTimer) {
			spaceshipController.transform.position = Vector3.Lerp(posSpaceship,finalPosSpaceship,t/outOfBoundsTimer);
			t += Time.deltaTime;
			yield return null;
		}
		
		spaceshipController.SpaceshipMovement.RestartMovement();

	}



	IEnumerator MoveCamera() {
		
		spaceshipController.SpaceshipMovement.StopMovement();
		var currentPosCamera = mainCamera.transform.position;
		var posSpaceship = spaceshipController.transform.position;
		var finalPosSpaceship = currentFloor.transform.position; 
		var finalPosCamera = new Vector3(currentFloor.transform.position.x, currentFloor.transform.position.y, mainCamera.transform.position.z);
		float t = 0f;
		
		while (t < timerMovement) {
			mainCamera.transform.position = Vector3.Lerp(currentPosCamera,finalPosCamera,t/ timerMovement);
			spaceshipController.transform.position = Vector3.Lerp(posSpaceship,finalPosSpaceship,t/ timerMovement);
			t += Time.deltaTime;
			yield return null;
		}
		
		mainCamera.transform.position = new Vector3(finalPosCamera.x, finalPosCamera.y, mainCamera.transform.position.z);
		if (!floorGenerator.IsCurrentFloorFinal(currentFloor)) {
			obstacleSpawner.ChangeCollider(currentFloor.GetComponent<Collider>());
			currentFloor.ActiveFloorCollider();
		}
		spaceshipController.SpaceshipMovement.RestartMovement();
	}






}