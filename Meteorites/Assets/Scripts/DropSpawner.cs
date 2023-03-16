using System;
using System.Collections.Generic;
using UnityEngine;

public class DropSpawner : MonoBehaviour {
	
	public GameObject dropObject;
	
	public void Spawn(Drop drop,Vector3 posSpawn) {
		var dropObj= Instantiate(dropObject, posSpawn, Quaternion.identity);
		var dropComponent = dropObj.GetComponent<DropComponent>();
		dropComponent.Init(drop);
	}
}

[Serializable]
public class MapDropSpawnProbability {

	public List<Drop> drops;
	public Vector2 rangeProbability;
	
}


[Serializable]
public class TableReductionRange {
	
	public Vector2 dimension;
	public float lowerRange;
}


