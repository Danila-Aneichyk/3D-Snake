using UnityEngine;

namespace Spawners
{
    public class FoodSpawner : MonoBehaviour
    {
        [SerializeField] public GameObject _foodPrefab;
        [SerializeField] private Transform _sphereTransform;
        private float _spawnInterval = 5.0f;
        private float _planetTransform = 25.5f;
        private float _nextSpawnTime;

        private void Start()
        {
            _nextSpawnTime = Time.time + _spawnInterval;
        }

        private void Update()
        {
            if (Time.time >= _nextSpawnTime)
            {
                SpawnFood();
                _nextSpawnTime = Time.time + _spawnInterval;
            }
        }

        private void SpawnFood()
        {
            float angle = Random.Range(0f, 360f);

            float radians = angle * Mathf.Deg2Rad;

            Vector3 foodPosition = _sphereTransform.position + _planetTransform * new Vector3(
                Mathf.Cos(radians),
                Mathf.Sin(radians),
                0f
            );

            Instantiate(_foodPrefab, foodPosition, Quaternion.identity);
        }
    }
}