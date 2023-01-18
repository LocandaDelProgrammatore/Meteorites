using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMovement : MonoBehaviour {

    public float speed;
    [SerializeField] GameObject modelObject;
    private Camera camera;
    private bool canMove;

    public void StopMovement() => canMove = false;

    private void Awake() {
	    //modelObject = GetComponentInChildren<GameObject>();
	    camera = Camera.main;
	    canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
	    if (canMove) {
		   SetMovement();
	    }
    }


    void SetMovement() {
	    if (Input.GetKey(KeyCode.W)) {
		    transform.position += transform.up * speed * Time.deltaTime;
	    }

	    if (Input.GetKey(KeyCode.S)) {
		    transform.position += -transform.up * speed * Time.deltaTime;
	    }

	    if (Input.GetKey(KeyCode.A)) {
		    transform.position += -transform.right * speed * Time.deltaTime;
	    }

	    if (Input.GetKey(KeyCode.D)) {
		    transform.position += transform.right * speed * Time.deltaTime;
	    }

	    Vector3 diff = camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
	    diff.Normalize();

	    float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
	    modelObject.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

    }








}
