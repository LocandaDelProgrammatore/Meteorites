using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FloorGenerator : MonoBehaviour {

	public Action<List<FloorManager>> OnFinishIstanciate;
	
	public int n = 5, m = 5;

	public const int N = 4;
	public const int M = 4;
	public float offsetX, offsetY;
	
	private FloorManager[,] mapFloor = new FloorManager[N,M];
	
	private List<FloorManager> floorGenerated = new List<FloorManager>();

	public GameObject floorInstance;

	private float localScaleX, localScaleY;

	private int currentIndex;

	public List<FloorManager> FloorGenerated => floorGenerated;

	private void Awake() {
		localScaleX = floorInstance.transform.localScale.x;
		localScaleY = floorInstance.transform.localScale.y;
		GenerateFloor();
	}

	public FloorManager GetFloorBasedOnIndex(int x, int y) {
		return mapFloor[x, y];
	}

	public void GenerateFloor() {
		
		var firstFloor = Instantiate(floorInstance, Vector3.zero, floorInstance.transform.rotation, transform);
		var floorComponent = firstFloor.GetComponent<FloorManager>();
		floorGenerated.Add(floorComponent);
		floorComponent.SetIndex(N/2,M/2,N, M);
		mapFloor[N / 2, M / 2] = floorComponent;
		StartCoroutine(CreateNeighBorFloors(floorComponent.indexX,floorComponent.indexY));
	}


	IEnumerator CreateNeighBorFloors(int x,int y) {
		CreateNeighBor(x,y-1);
		yield return null;
		CreateNeighBor(x+1,y);
		yield return null;
		CreateNeighBor(x,y+1);
		yield return null;
		CreateNeighBor(x-1,y);
		yield return null;
		
		if (floorGenerated.Count < N * M) {
			
			currentIndex ++;
			var floorComponent = floorGenerated[currentIndex];
			StartCoroutine(CreateNeighBorFloors(floorComponent.indexX,floorComponent.indexY));
		}
		else {
			OnFinishIstanciate?.Invoke(floorGenerated);
		}

	}


	void CreateNeighBor(int x, int y) {
		
		if (x < 0 || x > N-1 || y <0 || y > M-1) {
			return;
		}
		
		if (mapFloor[x, y] != null) {
			return;	
		}
		float XPos = (x - N / 2) * localScaleX * 10 * offsetX;
		float YPos = (M / 2-y) * localScaleY * 10 * offsetY;
		Vector3 posInstance = new Vector3(XPos, YPos);
		var firstFloor = Instantiate(floorInstance, posInstance, floorInstance.transform.rotation, transform);
		var floorComponent = firstFloor.GetComponent<FloorManager>();
		floorGenerated.Add(floorComponent);
		floorComponent.SetIndex(x,y,N,M);
		mapFloor[x,y] = floorComponent;
		
	}



}