using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using RPG.Combat;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
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
            if(slotIndex<4 &&!slotImages[slotIndex].isActiveAndEnabled)
            {
                pickedPickUps[slotIndex]=pickup;
                switch(pickup.pickUp)
                {
                    case PickUp.Bow:
                        slotImages[slotIndex].enabled = true;
                        slotImages[slotIndex].sprite = pickUpImages[1];
                        break;
                    case PickUp.FireBall:
                        slotImages[slotIndex].enabled = true;
                        slotImages[slotIndex].sprite = pickUpImages[0];
                        break;
                    case PickUp.Sword:
                        slotImages[slotIndex].enabled = true;
                        slotImages[slotIndex].sprite = pickUpImages[2];
                        break;
                }
                
                
            }
            slotIndex++;
           
        }

        private void Start()
        {
            pickedPickUps = new PickUpInfo[4];
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z)&&pickedPickUps[0].isEquipped&&pickedPickUps[0].usesLeft==-1)
            {
                playerFighter.EquipWeapon(pickedPickUps[0].weapon);
            }else if(Input.GetKeyDown(KeyCode.Z)&&pickedPickUps[0].isEquipped&&pickedPickUps[0].usesLeft>0)
            {
                Debug.Log("You can't use this weapon, it's health potion");
                pickedPickUps[0].health.PotionHealthRegen(pickedPickUps[0].potion.GetRegenAmount());
                pickedPickUps[0].usesLeft--;
            }
            if (Input.GetKeyDown(KeyCode.X)&&pickedPickUps[1].isEquipped&&pickedPickUps[1].usesLeft==-1)
            {
                playerFighter.EquipWeapon(pickedPickUps[1].weapon);
            }
            else if(Input.GetKeyDown(KeyCode.X)&&pickedPickUps[1].isEquipped&&pickedPickUps[1].usesLeft>0)
            {
                Debug.Log("You can't use this weapon, it's health potion");
                pickedPickUps[1].health.PotionHealthRegen(pickedPickUps[1].potion.GetRegenAmount());
                pickedPickUps[1].usesLeft--;
            }
            if (Input.GetKeyDown(KeyCode.C)&&pickedPickUps[2].isEquipped&&pickedPickUps[2].usesLeft==-1)
            {
                playerFighter.EquipWeapon(pickedPickUps[2].weapon);
            }else if(Input.GetKeyDown(KeyCode.C)&&pickedPickUps[2].isEquipped&&pickedPickUps[2].usesLeft>0)
            {
                Debug.Log("You can't use this weapon, it's health potion");
                pickedPickUps[2].health.PotionHealthRegen(pickedPickUps[2].potion.GetRegenAmount());
                pickedPickUps[2].usesLeft--;
            }
            if (Input.GetKeyDown(KeyCode.V)&&pickedPickUps[3].isEquipped&&pickedPickUps[3].usesLeft==-1)
            {
                playerFighter.EquipWeapon(pickedPickUps[3].weapon);
            }else if(Input.GetKeyDown(KeyCode.V)&&pickedPickUps[3].isEquipped&&pickedPickUps[3].usesLeft>0)
            {
                Debug.Log("You can't use this weapon, it's health potion");
                pickedPickUps[3].health.PotionHealthRegen(pickedPickUps[3].potion.GetRegenAmount());
                pickedPickUps[3].usesLeft--;
            }
        }
    }   
}
