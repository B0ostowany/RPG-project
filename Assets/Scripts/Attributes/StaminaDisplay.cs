using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RPG.Stats;

namespace RPG.Attributes
{
    public class StaminaDisplay : MonoBehaviour
    {
        Stamina stamina;

        private void Awake()
        {
            stamina = GameObject.FindWithTag("Player").GetComponent<Stamina>();
        }

        private void Update()
        {
            //health.GetHealthPoints(),health.GetMaxHealthPoints());
            GetComponent<Image>().fillAmount = stamina.GetStaminaValue()/stamina.GetMaxStaminaValue();
        }
    }

}