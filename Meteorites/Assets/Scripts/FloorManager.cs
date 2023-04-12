using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour {

	public Action<int, int> OnChangeFloorRequested;
	public int indexX, indexY;
	public List<FloorCollider> floorColliders;
	private int maxX, maxY;

	private void Awake() {
		foreach (var floorCollider in floorColliders) {
			floorCollider.OnPlayerCollide += TryChangeFloor;
			floorCollider.gameObject.SetActive(false);
		}
	}


	public void ActiveFloorCollider() {
		foreach (var floorCollider in floorColliders) {
			floorCollider.gameObject.SetActive(true);
		}
	}

	public void TurnoffCollider() {
		foreach (var floorCollider in floorColliders) {
			floorCollider.gameObject.SetActive(false);
		}
	}


	private void TryChangeFloor(Direction direction) {

		switch (direction) {
			case Direction.Nord :
				if (indexY - 1 >= 0) {
					OnChangeFloorRequested?.Invoke(indexX,indexY-1);
				}
				return;
			case Direction.Sud:
				if (indexY + 1 < maxY) {
					OnChangeFloorRequested?.Invoke(indexX,indexY+1);
					
				}
				return;
			case Direction.Est :
				if (indexX - 1 >= 0) {
					OnChangeFloorRequested?.Invoke(indexX-1,indexY);
				}
				return;
			
			case Direction.Ovest : 
				if (indexX + 1 < maxX) {
					OnChangeFloorRequested?.Invoke(indexX+1,indexY);
				}
				return;
		}
	}
	

	public void SetIndex(int N, int M,int mX, int mY) {
		indexX = N;
		indexY = M;
		maxX = mX;
		maxY = mY;
	}
}


