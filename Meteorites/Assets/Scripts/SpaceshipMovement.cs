using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMovement : MonoBehaviour {

    public float speed;
    [SerializeField] GameObject modelObject;
    private Camera camera;
    private bool canMove;
    private Plane movementPlane;
    private Vector3 prevPos;
    private Vector3 currPos;

    public void StopMovement() => canMove = false;

    private void Awake() {
	    //modelObject = GetComponentInChildren<GameObject>();
	    camera = Camera.main;
	    canMove = true;
	    movementPlane = new Plane(Vector3.forward,transform.position);
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
		    transform.position += Vector3.up * speed * Time.deltaTime;
	    }

	    if (Input.GetKey(KeyCode.S)) {
		    transform.position += -Vector3.up * speed * Time.deltaTime;
	    }

	    if (Input.GetKey(KeyCode.A)) {
		    transform.position += -Vector3.right * speed * Time.deltaTime;
	    }

	    if (Input.GetKey(KeyCode.D)) {
		    transform.position += Vector3.right * speed * Time.deltaTime;
	    }


	    float distance = 0;
	    Ray ray = camera.ScreenPointToRay((Input.mousePosition));
	    if (movementPlane.Raycast(ray, out distance)) {
		    currPos = ray.GetPoint(distance);
		    transform.LookAt(currPos, Vector3.back);
		    // if (prevPos != Vector3.zero) {
			   //  var point = Vector3.Lerp(prevPos, currPos, 0.5f);
			   //  transform.LookAt(point,Vector3.back);
		    // }
		    // else {
			   //  
			   //  prevPos = currPos;
		    // }
	    }
	    
	    
	    
	    
	    
	    
	    // Vector2 diff = camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
	    // diff.Normalize();
	    //
	    // //var angle = Vector2.Angle(diff, new Vector2(1, 0));
	    // float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
	    //
	    // modelObject.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

    }








}
