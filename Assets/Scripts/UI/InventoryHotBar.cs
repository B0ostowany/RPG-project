using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using RPG.Combat;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Debug = UnityEngine.Debug;
using Image = UnityEngine.UI.Image;


namespace RPG.UI
{
    public class InventoryHotBar : MonoBehaviour
    {
        [SerializeField] private List<Sprite> pickUpImages;
        [SerializeField] private List<Image> slotImages;
        [SerializeField] private PickUpInfo[] pickedPickUps;
        [SerializeField] private Fighter playerFighter;
        int slotIndex = 0;
        public void AddWeaponToHotbar(PickUpInfo pickup)
        {   
            if(slotIndex<3 &&!slotImages[slotIndex].isActiveAndEnabled)
            {
                pickedPickUps[slotIndex]=pickup;
                switch(pickup.pickUp)
                {
                    case PickUp.Bow:
                        pickup.slot = slotIndex;
                        slotImages[slotIndex].enabled = true;
                        slotImages[slotIndex].sprite = pickUpImages[1];
                        break;
                    case PickUp.FireBall:
                        pickup.slot = slotIndex;
                        slotImages[slotIndex].enabled = true;
                        slotImages[slotIndex].sprite = pickUpImages[0];
                        break;
                    case PickUp.Sword:
                        pickup.slot = slotIndex;
                        slotImages[slotIndex].enabled = true;
                        slotImages[slotIndex].sprite = pickUpImages[2];
                        break;
                }
                
                
            }
            slotIndex++;
           
        }

        private void Start()
        {
            pickedPickUps = new PickUpInfo[3];
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z)&&pickedPickUps[0].isEquipped)
            {
                playerFighter.EquipWeapon(pickedPickUps[0].weapon);
            }
            if (Input.GetKeyDown(KeyCode.X)&&pickedPickUps[1].isEquipped)
            {
                playerFighter.EquipWeapon(pickedPickUps[1].weapon);
            }
            if (Input.GetKeyDown(KeyCode.C)&&pickedPickUps[2].isEquipped)
            {
                playerFighter.EquipWeapon(pickedPickUps[2].weapon);
            }
        }
    }   
}
