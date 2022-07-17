using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RPG.Stats;

namespace RPG.Attributes
{
    public class ManaDisplay : MonoBehaviour
    {
        Mana mana;

        private void Awake()
        {
            mana = GameObject.FindWithTag("Player").GetComponent<Mana>();
        }

        private void Update()
        {
            //health.GetHealthPoints(),health.GetMaxHealthPoints());
            GetComponent<Image>().fillAmount = mana.GetManaValue()/mana.GetMaxManaValue();
        }
    }

}