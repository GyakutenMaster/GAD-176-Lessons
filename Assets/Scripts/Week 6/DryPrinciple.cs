using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DryPrinciple : MonoBehaviour
{
    // Compliant: DRY principle followed with a function for common logic
    // D - Do Not
    // R - Repeat
    // Y - Yourself

    //public class Player
    //{

    //    /*
    //    // Non-Compliant: DRY principle violated with duplicated logic
    //    public class Player
    //    {
    //        private int health;

    //        public void TakeDamage(int amount)
    //        {
    //            health -= amount;

    //            // Duplicated logic for health check
    //            if (health <= 0)
    //            {
    //                Die();
    //            }
    //            else if (health > 100)
    //            {
    //                health = 100;
    //            }
    //        }

    //        public void Heal(int amount)
    //        {
    //            health += amount;

    //            // Duplicated logic for health check
    //            if (health <= 0)
    //            {
    //                Die();
    //            }
    //            else if (health > 100)
    //            {
    //                health = 100;
    //            }
    //        }

    //        private void Die()
    //        {
    //            // Game over logic
    //        }
    //    }
    //    */
    //}

    // Compliant: DRY principle followed with a function for common logic
    public class Player
    {
        private int health;

        public void ChangeHealth(int amount)
        {
            health = Mathf.Clamp(health + amount, 0, 100);
            CheckHealth();
        }

        private void CheckHealth()
        {
            // Common logic to check and handle health status
            if (health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            // Game over logic
        }
    }
}
