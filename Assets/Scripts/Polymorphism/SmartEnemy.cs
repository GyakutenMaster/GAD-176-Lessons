using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.GAD176.Tutorials.Polymorphism
{
    public class SmartEnemy : FastEnemy
    {
        // Start is called before the first frame update
        void Start()
        {
            playerReference = FindAnyObjectByType<Player>();
            RunAtPlayer();
        }

        // Update is called once per frame
        void Update()
        {

            HitPlayer();
        }

        protected void HitPlayer()
        {
            if (playerReference)
            {
                if (Vector3.Distance(transform.position, playerReference.transform.position) < 1)
                {
                    Debug.Log("Dealing Damage to the player!");
                }
            }
        }
    }
}

