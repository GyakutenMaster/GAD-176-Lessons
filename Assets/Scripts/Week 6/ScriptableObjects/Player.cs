using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Weapon currentlyEquipped;
    private int currentIndex;
    public List<Weapon> allWeapons = new List<Weapon>();
    public List<Weapon> allInstancedWeapons = new List<Weapon>(); // creates a list only for the player to use, while the above list is used by all other characters.

    // Start is called before the first frame update
    void Start()
    {
        CreateWeaponInstances();
        currentIndex = 0;
        currentlyEquipped = allInstancedWeapons[currentIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            // fire the weapon
            currentlyEquipped.ShootWeapon();
        }

        if(Input.GetKeyDown(KeyCode.X))
        {
            currentIndex++;

            if(currentIndex >= allInstancedWeapons.Count)
            {
                currentIndex = 0;
            }
            currentlyEquipped = allInstancedWeapons[currentIndex];
        }
    }

    void CreateWeaponInstances()
    {
        for (int i = 0; i < allWeapons.Count; i++)
        {
            allInstancedWeapons.Add(ScriptableObject.Instantiate(allWeapons[i]));
        }
    }

    // Can use it as a weapon system like in Counter Strike where the shop system are all Scriptable Objects.
    // Its effectively data containers for those weapons with all the information related to it.
    // If you click the "Buy" button, you are creating a new instance of that object.

    // In Pokemon, you are creating a list of 151 Scriptable Objects of Pokemon.
    // And when you enter a battle, you create a new instance of that Scriptable Object.
    // When you throw a PokeBall, you are "capturing" that instance and storing in your list of team members.
}
