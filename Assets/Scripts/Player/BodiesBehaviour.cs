using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class BodiesBehaviour : MonoBehaviour
    {
        [Header("Bodies")]
        [SerializeField] private GameObject _bodyPrefab;
        [SerializeField] private List<Transform> _bodies;
        [Range(0, 4)]
        [SerializeField] private float _bodiesDistance;

        private Transform _transform;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
        }

        private void MoveBodies()
        {
            float sqrDistance = _bodiesDistance * _bodiesDistance;
            Vector3 previousBodyPosition = _transform.position;

            foreach (Transform body in _bodies)
            {
                if ((body.position - previousBodyPosition).sqrMagnitude > sqrDistance)
                {
                    body.position = previousBodyPosition;
                }
            }
        }
    }
}