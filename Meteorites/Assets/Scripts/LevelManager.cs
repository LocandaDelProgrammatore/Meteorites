using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	[SerializeField] private FloorGenerator floorGenerator;
	[SerializeField] private ObstacleSpawner obstacleSpawner;
	[SerializeField] private SpaceshipController spaceshipController;
	[SerializeField] FloorManager currentFloor;
	[SerializeField] private float timerMovement;
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
		}
	}


	private void UpdateCurrentFloor(int x,int y) {
		currentFloor.TurnoffCollider();
		currentFloor = floorGenerator.GetFloorBasedOnIndex(x, y);
		StartCoroutine(MoveCamera());
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
		obstacleSpawner.ChangeCollider(currentFloor.GetComponent<Collider>());
		currentFloor.ActiveFloorCollider();
		spaceshipController.SpaceshipMovement.RestartMovement();
	}






}