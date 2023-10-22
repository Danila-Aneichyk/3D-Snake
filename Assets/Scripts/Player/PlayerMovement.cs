using StaticTags;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement values")]
        [SerializeField] private float speed = 4;

        private FixedJoystick _joystick;
        private Rigidbody _rb;
        private GameObject _planet;
        private float _rotationSpeed = 150;
        private float _gravity = 100;
        private Vector3 _groundNormal;

        private void Start()
        {
            _planet = GameObject.FindGameObjectWithTag(Tags.Planet);
            _joystick = GameObject.FindGameObjectWithTag(Tags.Joystick).GetComponent<FixedJoystick>();
            _rb = GetComponent<Rigidbody>();
            _rb.freezeRotation = true;
        }

        private void Update()
        {
            GroundCheck();
            UseGravity();
            Rotate();
        }

        private void FixedUpdate()
        {
            _rb.velocity = transform.forward * speed;
        }

        private void GroundCheck()
        {
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(transform.position, -transform.up, out hit, 10))
            {
                _groundNormal = hit.normal;
            }
        }

        private void Rotate()
        {
            Quaternion toRotation = Quaternion.FromToRotation(transform.up, _groundNormal) * transform.rotation;
            transform.rotation = toRotation;
            float rotationInput = _joystick.Horizontal;
            transform.Rotate(0, rotationInput * _rotationSpeed * Time.deltaTime, 0);
        }

        private void UseGravity()
        {
            Vector3 gravDirection = (transform.position - _planet.transform.position).normalized;
            _rb.AddForce(gravDirection * -_gravity);
        }
    }
}