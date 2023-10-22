using System;
using StaticTags;
using UnityEngine;

namespace Objects
{
    public class Food : MonoBehaviour
    {
        public Action OnFoodEaten;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag(Tags.Player))
                return;
            
            OnFoodEaten?.Invoke();
            Destroy(gameObject);
        }
    }
}