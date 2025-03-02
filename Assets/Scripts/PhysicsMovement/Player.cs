using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.GAD176.Tutorials.PhysicsMovement
{
    public class Player : MonoBehaviour
    {
        // You could have different enemies with different movement systems, or different player controllers, or items that change your movement style like sliding boots.

        [SerializeField] private Rigidbody rb;
        [SerializeField] private float speed = 2;
        [SerializeField] private float rotateSpeed = 10;

        [SerializeField] private float dragFactor = 0.1f;

        [SerializeField] private float acceleration = 10f; // acceleration more of a gradual build up of speed

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            //MoveWithForces();
            //MoveWithVelocity();
            MoveWithRigidbody();
        }

        // Drag simulates air resistance as well as gradually slowing down objects.
        private void FixedUpdate()
        {
            //if(rb)
            //{
            //    // taking the opposite direction we are heading, and multiplying it by the drag factor
            //    rb.AddForce(-rb.velocity * dragFactor);
            //}
        }

        private void MoveWithRigidbody()
        {
            Vector3 movementVector = new Vector3();
            movementVector.x = Input.GetAxis("Horizontal");
            movementVector.z = Input.GetAxis("Vertical");

            if (rb)
            {
                rb.MovePosition(transform.position + transform.TransformDirection((movementVector * speed * Time.deltaTime)));
            }
        }

        private void MoveWithVelocity()
        {
            Vector3 movementVector = new Vector3();
            movementVector.x = Input.GetAxis("Horizontal");
            movementVector.z = Input.GetAxis("Vertical");

            movementVector = movementVector.normalized;

            if(rb)
            {
                rb.velocity += transform.TransformDirection(movementVector) * acceleration * Time.deltaTime;
            }
        }

        private void MoveWithForces()
        {
            Vector3 movementVector = new Vector3();
            movementVector.x = Input.GetAxis("Horizontal");
            movementVector.z = Input.GetAxis("Vertical");

            // this is regular kinematic movement.
            //transform.Translate(movementVector * speed * Time.deltaTime);

            if(rb)
            {
                // rb.AddForce(movementVector * speed);
                rb.AddRelativeForce(movementVector * speed);
            }

            // Applied forces
            if(Input.GetKey(KeyCode.E))
            {
                rb.AddTorque(Vector3.up * rotateSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.Q))
            {
                rb.AddTorque(Vector3.up * -rotateSpeed * Time.deltaTime);
                // I can always clamp the rotate force using vector3.ClampMagnitude
                // rb.AddExplosionForce is used to push any RigidBody around outwards.
                // rb.AddForceAtPosition can add a force at a specific point. Useful for force pusing a door.
            }
        }
    }
}