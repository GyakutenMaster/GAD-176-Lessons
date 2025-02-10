using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.GAD176.Tutorials.Polymorphism
{
    public class Enemy : MonoBehaviour 
    {
        protected Player playerReference; // protected acts just like private, no other scrpts can access or modify it, unless it is inheriting from this class.
        [SerializeField] protected float health = 100;

        // Start is called before the first frame update
        void Start()
        {
            // get a refenrence to the player
            playerReference = FindAnyObjectByType<Player>();
            Shout();
        }

        // Update is called once per frame
        void Update()
        {
           
        }

        protected void Shout()
        {
            if (playerReference)
            {
                if (Vector3.Distance(transform.position, playerReference.transform.position) < 5)
                {
                    Debug.Log("Shouting out to others. " + transform.name);
                }
            }
        }

        public void ChangeHealth (float amount)
        {
            health += amount;
        }
    }
}
