using UnityEngine;

namespace Spawners
{
    public class FoodSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _foodPrefab;
        [SerializeField] private Transform _sphereTransform;
        [SerializeField] private float _spawnRadius = 10.0f;
        [SerializeField] private float _spawnInterval = 5.0f;
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
            float randomTheta = Random.Range(0f, Mathf.PI * 2);
            float randomPhi = Random.Range(0f, Mathf.PI);

            float x = _spawnRadius * Mathf.Sin(randomPhi) * Mathf.Cos(randomTheta);
            float y = _spawnRadius * Mathf.Sin(randomPhi) * Mathf.Sin(randomTheta);
            float z = _spawnRadius * Mathf.Cos(randomPhi);

            Vector3 foodPosition = _sphereTransform.position + new Vector3(x, y, z);

            Instantiate(_foodPrefab, foodPosition, Quaternion.identity);
        }
    }
}