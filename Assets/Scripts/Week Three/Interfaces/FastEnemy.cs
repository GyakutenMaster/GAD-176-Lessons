using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.GAD176.Tutorials.Inheritance
{
    public class FastEnemy : Enemy
    {
        // Update is called once per frame
        void Update()
        {
            RunAtPlayer();
        }

        protected void RunAtPlayer()
        {
            if (playerReference)
            {
                if (Vector3.Distance(transform.position, playerReference.transform.position) < 10)
                {
                    Debug.Log("Running straight at the player! " + transform.name);
                }
            }
        }
    }
}
