using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.GAD176.Tutorials.ResponsiveUI
{
    [CreateAssetMenu(fileName = "New UI Weapon", menuName = "Create new UI Item", order = 0)]
    public class Weapon : ScriptableObject
    {
        public int cost;
        public string weaponName;

        public void Buy(ref int playerWallet)
        {
            if (playerWallet > cost)
            Debug.Log("You bought the weapon " + weaponName + ". It costed $" + cost);
            playerWallet -= cost;
        }

        /// <summary>
        /// check the player's wallet, and see if they can buy.
        /// </summary>
        /// <returns></returns>
        public bool CanBuy()
        {
            return true;
        }
    }
}
