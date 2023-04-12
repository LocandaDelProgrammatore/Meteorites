using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour {

    [SerializeField] private Collider planeCollider;
    [SerializeField] private int initialSpawnObstacle = 3;
    [SerializeField] private float timerSpawn = 2f;
    [SerializeField] private GameObject obstacleToSpawn;
    [SerializeField] private float offsetSpawn = 2f;
    [SerializeField] private bool spawnWithTimer;
    [SerializeField] private int obstacleToInstanceAfterExplosion;
    private float currentTimer;
    private float sizeX;
    private float sizeY;
    private List<ObstacleController> obstacleControllers = new List<ObstacleController>();
    
    private void Awake() {
        
    }


    public void InitSpawn(Collider collider) {
        planeCollider = collider;
        sizeX = planeCollider.bounds.size.x / 2;
        sizeY = planeCollider.bounds.size.y / 2;
        for (int i = 0; i < initialSpawnObstacle; i++) {
            Spawn();
        }
    }

    public void ChangeCollider(Collider collider) {
        DestroyAll();
        InitSpawn(collider);
    }


    private void DestroyAll() {
        foreach (var obstacleController in obstacleControllers) {
            Destroy(obstacleController.gameObject);
        }
        
        obstacleControllers.Clear();
    }

    private void Update() {
        if (spawnWithTimer) {
            UpdateTimer();
        }
    }



    private void UpdateTimer() {
        currentTimer += Time.deltaTime;
        if (currentTimer > timerSpawn) {
            currentTimer = 0;
            Spawn();
        }
    }

    private void Spawn(ObstacleController controller = null) {
        if(controller!= null) {
            obstacleControllers.Remove(controller);
        }
        Vector3 pos = ChoiceDirection(); 
        var obstacle = Instantiate(obstacleToSpawn, pos, Quaternion.identity);
        var obstacleMovementComponent = obstacle.GetComponent<ObstacleMovement>();
        if (!spawnWithTimer) {
            var obstacleController = obstacle.GetComponent<ObstacleController>();
            obstacleControllers.Add(obstacleController);
            obstacleController.Init(false);
            obstacleController.OnObstacleDeath += Spawn;
            obstacleController.OnObstacleRequestSpawn += SpawnAfterExplosion;
        }
        obstacleMovementComponent.Init(planeCollider);
    }


    private void SpawnAfterExplosion(Vector3 pos,float scaleParent) {
        for (int i = 0; i < obstacleToInstanceAfterExplosion; i++) {
            var obstacle = Instantiate(obstacleToSpawn, pos, Quaternion.identity);
            var obstacleMovementComponent = obstacle.GetComponent<ObstacleMovement>();
            var obstacleController = obstacle.GetComponent<ObstacleController>();
            obstacleController.Init(true,scaleParent);
            obstacleMovementComponent.Init(planeCollider);
        }
    }



    private Vector3 ChoiceDirection() {
        var indexAxis = Random.Range(0, 2);
        if (indexAxis == 0) {
            var xIndex = Random.Range(0, 2);
            var x = xIndex == 0 ? planeCollider.transform.position.x + sizeX + offsetSpawn : planeCollider.transform.position.x + (sizeX+offsetSpawn) * -1;
            var y = Random.Range(-sizeY, sizeY);
            y += planeCollider.transform.position.y;
            return new Vector3(x, y);
        }
        var yIndex = Random.Range(0, 2);
         var yTmp = yIndex == 0 ? planeCollider.transform.position.y + sizeY+offsetSpawn : planeCollider.transform.position.y + (sizeY+offsetSpawn) * -1;
         var xTmp = Random.Range(-sizeX, sizeX);
         xTmp += planeCollider.transform.position.x;
        return new Vector3(xTmp, yTmp);
        
    }

}
