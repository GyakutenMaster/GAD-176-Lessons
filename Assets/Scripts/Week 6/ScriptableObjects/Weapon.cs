using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// I can no longer get Start or Update as it is no longer a MonoBehaviour.
// Can only store variables and functions.
// We only store data that is shared, generic or general data. We typically use the data that doesn't change.

// You can't store scene references because they are acting very much like scripts.
// If I want to store scene related things, I have to it pass through function calls.
// If I want to pass in a transform; I will have to have a transform as a parameter tehre, rather than having a public transform and dragging it in.

// You can Inherit and Polymorph Scriptable Objects.

[CreateAssetMenu(fileName = "new weapon", menuName = "Create New Weapon", order = 0)]
public class Weapon : ScriptableObject
{
    public string weaponName;
    public int ammoAmount;
    public int clipSize;
    public int startingAmount;

    // variables

    // functions

    private void OnEnable()
    {
        ammoAmount = startingAmount;
    }

    public void ShootWeapon()
    {
        ammoAmount--;
        Debug.Log("I shot the " + weaponName + " it now has " + ammoAmount + "/" + clipSize);
    }
}
