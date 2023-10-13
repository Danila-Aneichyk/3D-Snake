using UnityEngine;

public class WorldConstraint : MonoBehaviour
{
    [Header("Transform of parent object")]
    [SerializeField] private Transform _world;

    private void FixedUpdate()
    {
        Quaternion rotation = Quaternion.FromToRotation(-transform.up, _world.position - transform.position);
        transform.rotation = rotation * transform.rotation; 
    }
}