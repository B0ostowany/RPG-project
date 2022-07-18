using UnityEngine;
using RPG.Attributes;

namespace RPG.Combat
{
    [CreateAssetMenu(fileName = "Potion", menuName = "Weapons/Make New Potion", order = 0)]
    public class Potion : ScriptableObject
    {
        [SerializeField] private int regenAmount = 10;
        [SerializeField] private float regenCooldown = 5f;
        [SerializeField] private int usesLeft=5;

        public int GetRegenAmount()
        {
            return regenAmount;
        }
        
        public float GetRegenCooldown()
        {
            return regenCooldown;
        }
        
        public int GetUsesLeft()
        {
            return usesLeft;
        }
    }
}