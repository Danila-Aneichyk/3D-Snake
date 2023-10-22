using UnityEngine;

namespace Spawners
{
    public class FoodSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject foodPrefab;
        [SerializeField] private Transform sphereTransform;
        [SerializeField] private float spawnRadius = 10.0f;
        [SerializeField] private float spawnInterval = 5.0f;
        private float nextSpawnTime;

        private void Start()
        {
            nextSpawnTime = Time.time + spawnInterval;
        }

        private void Update()
        {
            if (Time.time >= nextSpawnTime)
            {
                SpawnFood();
                nextSpawnTime = Time.time + spawnInterval;
            }
        }

        private void SpawnFood()
        {
            float randomTheta = Random.Range(0f, Mathf.PI * 2); // Угол вокруг оси Z (0-360 градусов).
            float randomPhi = Random.Range(0f, Mathf.PI); // Угол возвышения над плоскостью XY (0-180 градусов).

            float x = spawnRadius * Mathf.Sin(randomPhi) * Mathf.Cos(randomTheta);
            float y = spawnRadius * Mathf.Sin(randomPhi) * Mathf.Sin(randomTheta);
            float z = spawnRadius * Mathf.Cos(randomPhi);

            Vector3 foodPosition = sphereTransform.position + new Vector3(x, y, z);

            Instantiate(foodPrefab, foodPosition, Quaternion.identity);
        }
    }
}