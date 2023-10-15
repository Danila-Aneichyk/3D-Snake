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

        private float _gravity = 100;

        private Vector3 _groundNormal;

        private Rigidbody _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _rb.freezeRotation = true;
        }

        private void Update()
        {
            GroundCheck();
            UseGravity();
            Rotate();
        }

        private void GroundCheck()
        {
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(transform.position, -transform.up, out hit, 10))
            {
                _groundNormal = hit.normal;
            }
        }

        private void FixedUpdate()
        {
            _rb.velocity = transform.forward * speed;
        }

        private void Rotate()
        {
            Quaternion toRotation = Quaternion.FromToRotation(transform.up, _groundNormal) * transform.rotation;
            transform.rotation = toRotation;

            float rotationInput = _joystick.Horizontal;

            transform.Rotate(0, rotationInput * rotationSpeed * Time.deltaTime, 0);
        }

        private void UseGravity()
        {
            Vector3 gravDirection = (transform.position - Planet.transform.position).normalized;
            _rb.AddForce(gravDirection * -_gravity);
        }
    }
}