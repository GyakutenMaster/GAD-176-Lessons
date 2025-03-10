using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.GAD176.Tutorials.PhysicsCasting
{
    // Use it for guns or collision detection.

    public class PhysicsCasting : MonoBehaviour
    {
        public float raycastDistance = 10;
        public LayerMask raycastPhysicsLayers;
        bool enableSphereDebugging = false;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //RayCast();
            SphereCast();
        }

        void RayCast()
        {
            Debug.DrawRay(transform.position, transform.forward);

            RaycastHit hit; // store the thing I hit.

            if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance, raycastPhysicsLayers))
            {
                if(hit.transform.GetComponent<Enemy>())
                {
                    Debug.Log("Hit an enemy");
                }
            }
        }

        // Alternatiely use a Physics.Linecast; takes in the same parameters as the raycast.
        // except it takes in 2 positions in space.
        // where as a ray cast takes in a position and a direction.
        // we use a debug draw line.
        // That's why when you put a bucket on top a NPC in Skyrim, they can't see you because their raycast is blocked.

        //void LineCast()
        //{
        //    Physics.Linecast()
        //}

        void SphereCast()
        {
            Debug.DrawRay(transform.position, transform.forward);

            RaycastHit hit; // the first thing I hit with my sphere cast.

            enableSphereDebugging = true;
            if (Physics.SphereCast(transform.position, 1, transform.forward, out hit, raycastDistance, raycastPhysicsLayers))
            {
                if (hit.transform.GetComponent<Enemy>())
                {
                    Debug.Log("Hit an enemy");
                }
            }
        }

        private void OnDrawGizmos()
        {
            if (enableSphereDebugging)
            {
                for (int i = 0; i < raycastDistance; i++)
                {
                    Gizmos.DrawSphere(transform.position + (transform.forward * i), 1);
                }
            }
        }

        // SphereCastAll will be useful for something like a hyper beam that is in a straight line.
        // check Unity API for other shape casts, along with their Linecast equivalents.
    }
}
