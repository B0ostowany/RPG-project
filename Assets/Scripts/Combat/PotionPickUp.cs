using System.Collections;
using System.Collections.Generic;
using RPG.Attributes;
using RPG.UI;
using UnityEngine;

namespace RPG.Combat
{
    public class PotionPickUp : MonoBehaviour
    {
        [SerializeField] public InventoryHotBar hotBar;
        private PickUpInfo info;
        [SerializeField] private Potion potion;
        [SerializeField] float respawnTime=5f;
        [SerializeField] private PickUp pickUpType;

        private void Start()
        {
            info = new PickUpInfo();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag != "Player"||info.isEquipped) return;

            info.usesLeft = potion.GetUsesLeft();
            info.isEquipped = true;
            info.pickUp = pickUpType;
            info.potion = potion;
            info.health = other.GetComponent<Health>();
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
