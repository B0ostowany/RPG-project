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
        private bool isPaused = false;
        [SerializeField] private List<Sprite> pickUpImages;
        [SerializeField] private List<Image> slotImages;
        private PickUpInfo[] pickedPickUps;
        [SerializeField] private Fighter playerFighter;
        int slotIndex = 0;
        [SerializeField] private GameObject exitButton;
        public void AddWeaponToHotbar(PickUpInfo pickup)
        {   
            if(slotIndex<7 &&!slotImages[slotIndex].isActiveAndEnabled)
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
                    case PickUp.HealthPotion:
                        slotImages[slotIndex].enabled = true;
                        slotImages[slotIndex].sprite = pickUpImages[3];
                        break;
                    case PickUp.ManaPotion:
                        slotImages[slotIndex].enabled = true;
                        slotImages[slotIndex].sprite = pickUpImages[4];
                        break;
                    case PickUp.StaminaPotion:
                        slotImages[slotIndex].enabled = true;
                        slotImages[slotIndex].sprite = pickUpImages[5];
                        break;
                    case PickUp.Club:
                        slotImages[slotIndex].enabled = true;
                        slotImages[slotIndex].sprite = pickUpImages[6];
                        break;
                }
                
                
            }
            slotIndex++;
           
        }

        private void Start()
        {
            pickedPickUps = new PickUpInfo[7];
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z)&&pickedPickUps[0].isEquipped&&pickedPickUps[0].usesLeft==-1)
            {
                playerFighter.EquipWeapon(pickedPickUps[0].weapon);
            }else if(Input.GetKeyDown(KeyCode.Z)&&pickedPickUps[0].isEquipped&&pickedPickUps[0].usesLeft>0)
            {
                if (pickedPickUps[0].pickUp == PickUp.HealthPotion)
                {
                    Debug.Log("You can't use this weapon, it's health potion");
                    pickedPickUps[0].health.PotionHealthRegen(pickedPickUps[0].potion.GetRegenAmount());
                    pickedPickUps[0].usesLeft--;
                }else if (pickedPickUps[0].pickUp == PickUp.ManaPotion)
                {
                    pickedPickUps[0].mana.PotionManaRegen(pickedPickUps[0].potion.GetRegenAmount());
                    pickedPickUps[0].usesLeft--;
                }
                else if (pickedPickUps[0].pickUp == PickUp.StaminaPotion)
                {
                    pickedPickUps[0].stamina.PotionStaminaRegen(pickedPickUps[0].potion.GetRegenAmount());
                    pickedPickUps[0].usesLeft--;
                }
            }
            if (Input.GetKeyDown(KeyCode.X)&&pickedPickUps[1].isEquipped&&pickedPickUps[1].usesLeft==-1)
            {
                playerFighter.EquipWeapon(pickedPickUps[1].weapon);
            }
            else if(Input.GetKeyDown(KeyCode.X)&&pickedPickUps[1].isEquipped&&pickedPickUps[1].usesLeft>0)
            {
                Debug.Log("You can't use this weapon, it's health potion");
                if (pickedPickUps[1].pickUp == PickUp.HealthPotion)
                {
                    pickedPickUps[1].health.PotionHealthRegen(pickedPickUps[1].potion.GetRegenAmount());
                    pickedPickUps[1].usesLeft--;
                }else if (pickedPickUps[1].pickUp == PickUp.ManaPotion)
                {
                    pickedPickUps[1].mana.PotionManaRegen(pickedPickUps[1].potion.GetRegenAmount());
                    pickedPickUps[1].usesLeft--;
                }else if (pickedPickUps[1].pickUp == PickUp.StaminaPotion)
                {
                    pickedPickUps[1].stamina.PotionStaminaRegen(pickedPickUps[1].potion.GetRegenAmount());
                    pickedPickUps[1].usesLeft--;
                }
                
            }
            if (Input.GetKeyDown(KeyCode.C)&&pickedPickUps[2].isEquipped&&pickedPickUps[2].usesLeft==-1)
            {
                playerFighter.EquipWeapon(pickedPickUps[2].weapon);
            }else if(Input.GetKeyDown(KeyCode.C)&&pickedPickUps[2].isEquipped&&pickedPickUps[2].usesLeft>0)
            {
                if (pickedPickUps[2].pickUp == PickUp.HealthPotion)
                {
                    Debug.Log("You can't use this weapon, it's health potion");
                    pickedPickUps[2].health.PotionHealthRegen(pickedPickUps[2].potion.GetRegenAmount());
                    pickedPickUps[2].usesLeft--;
                }else if (pickedPickUps[2].pickUp == PickUp.ManaPotion)
                {
                    pickedPickUps[2].mana.PotionManaRegen(pickedPickUps[2].potion.GetRegenAmount());
                    pickedPickUps[2].usesLeft--;
                }else if (pickedPickUps[2].pickUp == PickUp.StaminaPotion)
                {
                    pickedPickUps[2].stamina.PotionStaminaRegen(pickedPickUps[2].potion.GetRegenAmount());
                    pickedPickUps[2].usesLeft--;
                }
            }
            if (Input.GetKeyDown(KeyCode.V)&&pickedPickUps[3].isEquipped&&pickedPickUps[3].usesLeft==-1)
            {
                playerFighter.EquipWeapon(pickedPickUps[3].weapon);
            }else if(Input.GetKeyDown(KeyCode.V)&&pickedPickUps[3].isEquipped&&pickedPickUps[3].usesLeft>0)
            {
                if (pickedPickUps[3].pickUp == PickUp.HealthPotion)
                {
                    Debug.Log("You can't use this weapon, it's health potion");
                    pickedPickUps[3].health.PotionHealthRegen(pickedPickUps[3].potion.GetRegenAmount());
                    pickedPickUps[3].usesLeft--;
                }else if (pickedPickUps[3].pickUp == PickUp.ManaPotion)
                {
                    pickedPickUps[3].mana.PotionManaRegen(pickedPickUps[3].potion.GetRegenAmount());
                    pickedPickUps[3].usesLeft--;
                }else if (pickedPickUps[3].pickUp == PickUp.StaminaPotion)
                {
                    pickedPickUps[3].stamina.PotionStaminaRegen(pickedPickUps[3].potion.GetRegenAmount());
                    pickedPickUps[3].usesLeft--;
                }
            }
            if (Input.GetKeyDown(KeyCode.B)&&pickedPickUps[4].isEquipped&&pickedPickUps[4].usesLeft==-1)
            {
                playerFighter.EquipWeapon(pickedPickUps[4].weapon);
            }else if(Input.GetKeyDown(KeyCode.B)&&pickedPickUps[4].isEquipped&&pickedPickUps[4].usesLeft>0)
            {
                if (pickedPickUps[4].pickUp == PickUp.HealthPotion)
                {
                    Debug.Log("You can't use this weapon, it's health potion");
                    pickedPickUps[4].health.PotionHealthRegen(pickedPickUps[4].potion.GetRegenAmount());
                    pickedPickUps[4].usesLeft--;
                }else if (pickedPickUps[4].pickUp == PickUp.ManaPotion)
                {
                    pickedPickUps[4].mana.PotionManaRegen(pickedPickUps[4].potion.GetRegenAmount());
                    pickedPickUps[4].usesLeft--;
                }else if (pickedPickUps[4].pickUp == PickUp.StaminaPotion)
                {
                    pickedPickUps[4].stamina.PotionStaminaRegen(pickedPickUps[4].potion.GetRegenAmount());
                    pickedPickUps[4].usesLeft--;
                }
            }
            if (Input.GetKeyDown(KeyCode.N)&&pickedPickUps[5].isEquipped&&pickedPickUps[5].usesLeft==-1)
            {
                playerFighter.EquipWeapon(pickedPickUps[5].weapon);
            }else if(Input.GetKeyDown(KeyCode.N)&&pickedPickUps[5].isEquipped&&pickedPickUps[5].usesLeft>0)
            {
                if (pickedPickUps[5].pickUp == PickUp.HealthPotion)
                {
                    Debug.Log("You can't use this weapon, it's health potion");
                    pickedPickUps[5].health.PotionHealthRegen(pickedPickUps[5].potion.GetRegenAmount());
                    pickedPickUps[5].usesLeft--;
                }else if (pickedPickUps[5].pickUp == PickUp.ManaPotion)
                {
                    pickedPickUps[5].mana.PotionManaRegen(pickedPickUps[5].potion.GetRegenAmount());
                    pickedPickUps[5].usesLeft--;
                }else if (pickedPickUps[5].pickUp == PickUp.StaminaPotion)
                {
                    pickedPickUps[5].stamina.PotionStaminaRegen(pickedPickUps[5].potion.GetRegenAmount());
                    pickedPickUps[5].usesLeft--;
                }
            }
            if (Input.GetKeyDown(KeyCode.M)&&pickedPickUps[6].isEquipped&&pickedPickUps[6].usesLeft==-1)
            {
                playerFighter.EquipWeapon(pickedPickUps[6].weapon);
            }else if(Input.GetKeyDown(KeyCode.M)&&pickedPickUps[6].isEquipped&&pickedPickUps[6].usesLeft>0)
            {
                if (pickedPickUps[6].pickUp == PickUp.HealthPotion)
                {
                    Debug.Log("You can't use this weapon, it's health potion");
                    pickedPickUps[6].health.PotionHealthRegen(pickedPickUps[6].potion.GetRegenAmount());
                    pickedPickUps[6].usesLeft--;
                }else if (pickedPickUps[6].pickUp == PickUp.ManaPotion)
                {
                    pickedPickUps[6].mana.PotionManaRegen(pickedPickUps[6].potion.GetRegenAmount());
                    pickedPickUps[6].usesLeft--;
                }else if (pickedPickUps[6].pickUp == PickUp.StaminaPotion)
                {
                    pickedPickUps[6].stamina.PotionStaminaRegen(pickedPickUps[6].potion.GetRegenAmount());
                    pickedPickUps[6].usesLeft--;
                }
            }
            
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                isPaused = !isPaused;
                exitButton.SetActive(isPaused);
            }
            
        }
        public void ExitGame()
        {
            Application.Quit();
        }
    }   
}
