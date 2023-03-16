using System;using UnityEngine;

public enum CategoryPower {
	
	Shoot,
	Bomb,
	Drones
}

public abstract class PowerDrop : Drop {

	public CategoryPower categoryPower;
	
	public virtual void Shoot(Vector3 pos,Quaternion rotation, Transform parent) { }
	
}