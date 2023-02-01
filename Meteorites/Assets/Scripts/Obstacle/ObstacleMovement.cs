using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleMovement : MonoBehaviour {
  
  [SerializeField] GameObject obstacleModel;
  [SerializeField] private float velocityRotation = 10f;
  [SerializeField] private Vector2 rangeVelocityRotation;
  [SerializeField] private Vector2 rangeTimerLerp;
  [SerializeField] private Collider planeCollider;
  [SerializeField] private float timerMovement;
  [SerializeField] private AnimationCurve curve;
  private float rangeX;
  private float rangeY;

  private void Awake() {
    velocityRotation = Random.Range(rangeVelocityRotation.x, rangeVelocityRotation.y);
    timerMovement = Random.Range(rangeTimerLerp.x, rangeTimerLerp.y);
    rangeX = planeCollider.bounds.size.x / 2;
    rangeY = planeCollider.bounds.size.y / 2;
    StartCoroutine(MoveObstacoleCor(CalculateNewPosition()));
    
  }

  private void Update() {
    obstacleModel.transform.Rotate(Vector3.forward*velocityRotation*Time.deltaTime);
    
  }

  private Vector2 CalculateNewPosition() {
    return new Vector2(Random.Range(-rangeX,rangeX),Random.Range(-rangeY,rangeY));
  }

  IEnumerator MoveObstacoleCor(Vector2 newPos) {
    var initPos = transform.position;
    float t = 0f;
    while (t < timerMovement) {
      transform.position = Vector3.Lerp(initPos,newPos, curve.Evaluate(t/timerMovement));
      t += Time.deltaTime;
      yield return null;
    }
    transform.position = newPos;
    yield return new WaitForSeconds(2f);
    StartCoroutine(MoveObstacoleCor(CalculateNewPosition()));

  }


}
