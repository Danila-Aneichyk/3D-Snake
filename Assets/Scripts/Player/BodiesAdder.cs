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

        private void Awake()
        {
            _foodDetector.OnFoodEaten += AddBody;
        }

        private void AddBody()
        {
            GameObject body = Instantiate(_bodyPrefab);
            _bodiesMovement._bodies.Add(body.transform);
        }
    }
}