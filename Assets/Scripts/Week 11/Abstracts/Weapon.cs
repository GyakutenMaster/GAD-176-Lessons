using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.GAD176.Tutorials.Abstracts
{
    public abstract class Weapon : MonoBehaviour
    {
        public string weaponName;
        public int damage;

        // abstract method that must be implemented by the derived

        public abstract void Attack();

        public void EquipWeapon()
        {
            Debug.Log("Equipping " + weaponName);
        }
    }
}
