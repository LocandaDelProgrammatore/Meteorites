using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UiPowerShoot : MonoBehaviour {
    
    [SerializeField] private Image spriteImage;
    private PowerDrop dropPower;

    public PowerDrop DropPower => dropPower;

    public void Awake() {
        spriteImage.sprite = null;
    }

    public void Init(PowerDrop drop) {
        dropPower = drop;
        spriteImage.sprite = dropPower.dropSprite;
    }

    public void DeInit() {
        dropPower = null;
        spriteImage.sprite = null;
    }


    public bool IsSameType(PowerDrop drop) {
        if (dropPower == null) {
            return false;
        }
        if (dropPower is BombDrop) {
            return false;
        }

        return drop.categoryPower == dropPower.categoryPower;
    }
}