using System;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        public GameObject Planet;
        public float speed = 4;
        public float rotationSpeed = 150;

        [SerializeField] private FixedJoystick _joystick;

        float gravity = 100;
        bool OnGround = false;

        float distanceToGround;
        Vector3 Groundnormal;

        private Rigidbody rb;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.freezeRotation = true;
        }

        // Update is called once per frame
        void Update()
        {
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(transform.position, -transform.up, out hit, 10))
            {
                distanceToGround = hit.distance;
                Groundnormal = hit.normal;

                if (distanceToGround <= 0.2f)
                {
                    OnGround = true;
                }
                else
                {
                    OnGround = false;
                }
            }

            //GRAVITY and ROTATION

            Vector3 gravDirection = (transform.position - Planet.transform.position).normalized;

            if (OnGround == false)
            {
                rb.AddForce(gravDirection * -gravity);
            }


            Quaternion toRotation = Quaternion.FromToRotation(transform.up, Groundnormal) * transform.rotation;
            transform.rotation = toRotation;

            float rotationInput = _joystick.Horizontal;

            transform.Rotate(0, rotationInput * rotationSpeed * Time.deltaTime, 0);
        }

        void FixedUpdate()
        {
            rb.velocity = transform.forward * speed;
        }
    }
}