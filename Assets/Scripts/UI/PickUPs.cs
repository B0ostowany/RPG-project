using RPG.Attributes;
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
        Club,
        Unarmed
    }
    
    public struct PickUpInfo
    {
        public PickUp pickUp;
        public bool isEquipped;
        public Weapon weapon;
        public Potion potion;
        public int usesLeft;
        public Health health;
        public Mana mana;
        public Stamina stamina;
    }

}