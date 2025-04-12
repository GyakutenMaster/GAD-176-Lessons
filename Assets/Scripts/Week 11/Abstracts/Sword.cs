using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.GAD176.Tutorials.Abstracts
{
    public class Sword : Weapon
    {
        public int swingSpeed = 10;

        public override void Attack()
        {
            Debug.Log("Swinging this sword called:" + weaponName + " at a speed of " + swingSpeed + "m/s and do " + damage + "damage.");
        }
    }
}