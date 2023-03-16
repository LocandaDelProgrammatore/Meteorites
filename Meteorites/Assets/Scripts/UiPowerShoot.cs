using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UiPowerShoot : MonoBehaviour {
    
    [SerializeField] private Image spriteImage;
    private PowerDrop dropPower;

    public void Awake() {
        spriteImage.sprite = null;
    }

    public void Init(PowerDrop drop) {
        dropPower = drop;
        spriteImage.sprite = dropPower.dropSprite;
    }



    public bool IsSameType(PowerDrop drop) {
        if (dropPower == null) {
            return false;
        }
        
        return drop.categoryPower == dropPower.categoryPower;
    }
}