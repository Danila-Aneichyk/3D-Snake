using StaticTags;
using UnityEngine;

namespace Player
{
    public class BodiesAdder : MonoBehaviour
    {
        [Header("Body prefab")]
        [SerializeField] private GameObject _bodyPrefab;

        [Header("Food detector component")]
        [SerializeField] private FoodDetector _foodDetector;

        [Header("Bodies movement component")]
        [SerializeField] private BodiesMovement _bodiesMovement;

        private Transform _planet;

        private void Awake()
        {
            _foodDetector.OnFoodEaten += AddBody;
            _planet = GameObject.FindGameObjectWithTag(Tags.Planet).transform;
        }

        private void AddBody()
        {
            GameObject body = Instantiate(_bodyPrefab, _planet.position, Quaternion.identity);
            _bodiesMovement._bodies.Add(body.transform);
        }
    }
}