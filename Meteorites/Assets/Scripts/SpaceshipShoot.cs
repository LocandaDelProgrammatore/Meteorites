using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipShoot : MonoBehaviour {
  
  
  public ShootPower shootPower;
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
    
    if (shootPower != null) {
      ShootWithPower();
    }
    else {
      ShootWithoutPower();
    }
  }


  private void ShootWithoutPower() {
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


  private void ShootWithPower() {
    if (canShoot) {
      if (Input.GetMouseButtonDown(0)) {
        canShoot = false;
        shootPower.Shoot(spaceShootSpawner.position, spaceShootSpawner.rotation, spaceShootSpawner);
      }
    }
    else {
      currentTimerRecharge += Time.deltaTime;
      if (currentTimerRecharge > shootPower.waitTimer) {
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



