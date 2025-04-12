using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
