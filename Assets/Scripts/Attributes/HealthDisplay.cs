using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RPG.Stats;

namespace RPG.Attributes
{
    public class HealthDisplay : MonoBehaviour
    {
        Health health;

        private void Awake()
        {
            health = GameObject.FindWithTag("Player").GetComponent<Health>();
        }

        private void Update()
        {
            //health.GetHealthPoints(),health.GetMaxHealthPoints());
            GetComponent<Image>().fillAmount = health.GetHealthPoints()/health.GetMaxHealthPoints();
            ;
        }
    }

}