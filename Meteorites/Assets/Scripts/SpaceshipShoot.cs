using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipShoot : MonoBehaviour {
  
  [SerializeField] private Transform spaceShootSpawner;
  [SerializeField] private GameObject bulletInstance;
  [SerializeField] private float timerRecharge = 0.5f;
  private bool canShoot;
  private float currentTimerRecharge;
  private AudioSource source;

  private void Awake() {
    source = GetComponent<AudioSource>();
  }

  private void Update() {
    if (canShoot) {
      if (Input.GetMouseButtonDown(0)) {
        Shoot();
      }
    }
    else {
      currentTimerRecharge += Time.deltaTime;
      if (currentTimerRecharge > timerRecharge) {
          currentTimerRecharge = 0;
          canShoot = true;
      }
    }
  }


  void Shoot() {
    Instantiate(bulletInstance, spaceShootSpawner.position, spaceShootSpawner.rotation, spaceShootSpawner);
    source.Play();
    canShoot = false;
  }
}




public class Equip : MonoBehaviour {
  
}