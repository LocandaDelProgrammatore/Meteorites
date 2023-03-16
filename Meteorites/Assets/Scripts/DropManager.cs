using System;
using UnityEngine;

public class DropManager : MonoBehaviour {

	public Action<Drop> OnDropRequested;
	
		

	public void RequestDrop(Drop drop) {
		OnDropRequested?.Invoke(drop);
	}

}