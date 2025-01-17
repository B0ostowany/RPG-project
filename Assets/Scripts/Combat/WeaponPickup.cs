using System;
using System.Collections;
using System.Collections.Generic;
using RPG.UI;
using UnityEngine;

namespace RPG.Combat
{
    public class WeaponPickup : MonoBehaviour
    {
        [SerializeField] private InventoryHotBar hotBar;
        [SerializeField] Weapon weapon = null;
        [SerializeField] float respawnTime=5f;
        [SerializeField] private PickUp pickUpType;
        [SerializeField] private int usesLeft=-1;
        private PickUpInfo info;

        private void Start()
        {
            info = new PickUpInfo();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag != "Player"||info.isEquipped) return;

            info.usesLeft = usesLeft;
            info.isEquipped = true;
            info.pickUp = pickUpType;
            info.weapon = weapon;
            other.GetComponent<Fighter>().EquipWeapon(weapon);
            StartCoroutine(HideForSeconds(respawnTime));
            hotBar.AddWeaponToHotbar(info);
            
        }

        private IEnumerator HideForSeconds(float seconds)
        {
            ShowPickup(false);
            yield return new WaitForSeconds(seconds);
            ShowPickup(true);
        }

        private void ShowPickup(bool ShouldShow)
        {
            GetComponent<Collider>().enabled = ShouldShow;
            foreach(Transform child in transform)
            {
                child.gameObject.SetActive(ShouldShow);
            }
        }
    }
}
