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
    public class Mana : MonoBehaviour, ISaveable
    {
        
        LazyValue<float> manaPoints;
        public bool isExhausted = false;
        private float manaTimer = 0f;
        // Start is called before the first frame update
        void Awake()
        {
            manaPoints = new LazyValue<float>(GetInitialMana);
        }
        
        
        public void UseMana(float usedMana)
        {
            manaPoints.value = Mathf.Max(manaPoints.value - usedMana, 0);
            if(manaPoints.value<=0)
            {
                isExhausted = true;
            }
            else
            {
                isExhausted = false;
            }
        }

        public void UpdateMana()
        {
            if(manaPoints.value<=0)
            {
                isExhausted = true;
            }
            else
            {
                isExhausted = false;
            }
        }
        
        public float GetManaValue()
        {
            return manaPoints.value;
        }
        public float GetMaxManaValue()
        {
            return GetComponent<BaseStats>().GetStat(Stat.Mana);
        }
        public float GetPercentageMana()
        {
            return manaPoints.value / GetInitialMana();
        }
        // Update is called once per frame
        void Update()
        {
            ConstantManaRegen();
        }
        private void ConstantManaRegen()
        {
            manaTimer+=Time.deltaTime;
            if(manaPoints.value<GetMaxManaValue()&&manaTimer>=1)
            {
                manaPoints.value += 10;
                manaTimer = 0;
            }
            
        }

        private float GetInitialMana()
        {
            return GetComponent<BaseStats>().GetStat(Stat.Mana);
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