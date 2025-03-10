using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Example of a namespace = company.project.system.subsystem
namespace SAE.GAD176.Characters.Health // use namespace to delineate your scrips from other people's scripts
{
    /// <summary>
    ///  Handles the health for our character.
    /// </summary>

    public class Encapsulation : MonoBehaviour
    {
        [SerializeField] private float health;
        // any variables and fuction that you declare or need, START them as private.
        // Only change this if we need to access it somewhere else.
        // when we do access it, it must be through a fucntion, not through variables.

        public float GetHealth()
        {
            return health;
        }

        /// <summary>
        /// Changes the health value by the amount, if the number is negative it will play "oof" sfx, if it's positive it will play heal sfx.
        /// </summary>
        /// <param name="amount"></param>

        public void ChangeHealth(float amount)
        {
            // the idea is they cna pass in positiv eor negative numbers and the health will change.
            health += amount;

            // I can check the amount coming in, if it's greater than 0 play a healing sfx.
            // if it's less than 0, play an "oof" sfx. amount > 0 amount < 0
        }

        #region Unity Specific Functions
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        #endregion

        #region custom functions
        // any fucntion that are used by this script exists here.
        #endregion
    }
}
