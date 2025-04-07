using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.GAD176.Tutorials.Events
{
    public class DamageObject : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            // deal some damage.
            // here I want to shou out.
            //if(GameEvents.OnDamageEvent != null)
            //{
            //    GameEvents.OnDamageEvent.Invoke(-20, other.transform);
            //}

            GameEvents.OnChangeHealthEvent?.Invoke(-25, other.transform); // same as above but using delegates.
        }
    }
}
