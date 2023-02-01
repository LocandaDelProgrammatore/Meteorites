using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionManagment : MonoBehaviour {

	public void DestroyElement() => Destroy(transform.parent.gameObject);
}
