using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


namespace RPG.UI
{
    public class InventoryHotBar : MonoBehaviour
    {
        [SerializeField] private List<GameObject> pickupPrefab;
        [SerializeField] private List<Transform> slotTransform;
        private Dictionary<Transform, bool> slotDictionary = null;
        int slotIndex = 0;
        public void AddWeaponToHotbar(PickUp pickup)
        {   
            if(slotDictionary[slotTransform[slotIndex]] == false)
            {
                switch(pickup)
                {
                    case PickUp.Bow:
                        Instantiate(pickupPrefab[0], slotTransform[slotIndex].position, Quaternion.identity);
                        break;
                    case PickUp.FireBall:
                        Instantiate(pickupPrefab[1], slotTransform[slotIndex].position, Quaternion.identity);
                        break;
                    case PickUp.Sword:
                        Instantiate(pickupPrefab[2], slotTransform[slotIndex].position, Quaternion.identity);
                        break;
                }
                slotDictionary[slotTransform[slotIndex]] = true;
                slotIndex++;
            }
            
           
        }

        private void Start()
        {
            slotDictionary = new Dictionary<Transform, bool>();
            foreach (var slot in slotTransform)
            {
                slotDictionary.Add(slot, false);
            }
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }   
}
