using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    public float fireRate = 5;

    public override void Attack()
    {
        Debug.Log("Shooting this weapon called:" + weaponName + " at a rate of " + fireRate + " bullets per second and do " + damage + "damage.");
    }
}
