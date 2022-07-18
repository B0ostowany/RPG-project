using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Saving;
using RPG.Stats;
using RPG.Core;
using System;
using GameDevTV.Utils;


namespace RPG.Attributes
{
    public class Stamina : MonoBehaviour, ISaveable
    {
        
        LazyValue<float> staminaPoints;
        public bool isExhausted = false;
        
        public float staminaTimer=0;

        private float staminaDrainTimer;
        // Start is called before the first frame update
        void Awake()
        {
            staminaPoints = new LazyValue<float>(GetInitialStamina);
        }
        
        
        public void UseStamina(float usedStamina)
        {
            staminaPoints.value = Mathf.Max(staminaPoints.value - usedStamina, 0);
            if(staminaPoints.value<=0)
            {
                isExhausted = true;
            }
            else
            {
                isExhausted = false;
            }
        }

        public void UpdateStamina()
        {
            if(staminaPoints.value<=0)
            {
                isExhausted = true;
            }
            else
            {
                isExhausted = false;
            }
        }
        
        public float GetStaminaValue()
        {
            return staminaPoints.value;
        }
        public float GetMaxStaminaValue()
        {
            return GetComponent<BaseStats>().GetStat(Stat.Stamina);
        }
        public float GetPercentageStamina()
        {
            return staminaPoints.value / GetInitialStamina();
        }
        public void PotionStaminaRegen(int regenAmount)
        {
            staminaPoints.value += regenAmount;
        }
        // Update is called once per frame
        void Update()
        {
            staminaDrainTimer+= Time.deltaTime;
            ConstantStaminaRegen();
            
        }

        private void ConstantStaminaRegen()
        {
            staminaTimer+=Time.deltaTime;
            if(staminaPoints.value<GetMaxStaminaValue()&&staminaTimer>=1)
            {
                staminaPoints.value += 10;
                staminaTimer = 0;
            }
            
        }
        private float GetInitialStamina()
        {
            return GetComponent<BaseStats>().GetStat(Stat.Stamina);
        }
        public bool IsExhausted()
        {
            return isExhausted;
        }

        public void IsRunning()
        {
            
        }
        
        
        
        public object CaptureState()
        {
            throw new NotImplementedException();
        }

        public void RestoreState(object state)
        {
            throw new NotImplementedException();
        }
    }
}
