using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.GAD176.Tutorials.Interfaces // If I find myself copying and pasting, it is a good sign that I should create a base Class and Inherit from it.
{
    public class Player : MonoBehaviour, IKillable//, ICollectable, IEquip, etc, I can keep on putting a comma and implement interfaces.
    {
        // public Weapon myWeapon;
        // public List<Weapon> inventory = new Lis  t<Weapon>();
        // For example, all guns will have the same basic function.

        public List<Enemy> allEnemiesInScene = new List<Enemy>();

        // Start is called before the first frame update
        void Start()
        {
            // search the scene for all the enemies, this include scripts inherit from enemy
            allEnemiesInScene.AddRange(FindObjectsOfType<Enemy>());

            for (int i = 0; i < allEnemiesInScene.Count; i++)
            {
                allEnemiesInScene[i].ChangeHealth(-20);
            }
        }

        // Update is called once per frame
        void Update()
        {
            // if the mouse click is pressed
            // myWrapon.Fire()
        }

        public bool IsAlive()
        {
            return false;
        }

        public float GetHealth()
        {
            return 0;
        }

        public float ReturnHealth()
        {
            return 0;
        }

        public void Kill()
        {

        }
    }
}
