using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.GAD176.Tutorials.Events
{
    public class Player : MonoBehaviour
    {
        
        public float health = 100;

        private void OnEnable()
        {
            GameEvents.OnChangeHealthEvent += DealDamage;
            GameEvents.OnDamageEvent += DealDamage;
            GameEvents.OnGameStartEvent += PrintName;
        }

        private void OnDisable()
        {
            GameEvents.OnChangeHealthEvent -= DealDamage;
            GameEvents.OnDamageEvent -= DealDamage;
            GameEvents.OnGameStartEvent -= PrintName;
        }

        private void PrintName()
        {
            Debug.Log("Jack");
        }

        private void DealDamage(float amount, Transform hitObjectTransform)
        {
            if(hitObjectTransform != null && hitObjectTransform != transform)
            {
                return;
            }
            // if we get here, I must be the transform that got hit.
            health += amount;
        }
    }
}
