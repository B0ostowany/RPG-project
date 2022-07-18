using RPG.Combat;
using UnityEngine;

namespace RPG.UI
{
    public enum PickUp
    { 
        Sword,
        Bow,
        FireBall,
        ManaPotion,
        HealthPotion,
        StaminaPotion,
        Unarmed
    }
    
    public struct PickUpInfo
    {
        public PickUp pickUp;
        public bool isEquipped;
        public Weapon weapon;
        public bool isWeapon;
        public int slot;
    }

}