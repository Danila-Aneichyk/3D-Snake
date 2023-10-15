using StaticTags;
using UnityEngine;

namespace WorldPhysics
{
    public class WorldConstraint : MonoBehaviour
    {
        [Header("Transform of parent object")]
        private Transform _planet;

        private void Start()
        {
            _planet = GameObject.FindGameObjectWithTag(Tags.Planet).transform;
        }

        private void FixedUpdate()
        {
            WorldAttraction();
        }

        private void WorldAttraction()
        {
            Quaternion rotation = Quaternion.FromToRotation(-transform.up, _planet.position - transform.position);
            transform.rotation = rotation * transform.rotation;
        }
    }
}