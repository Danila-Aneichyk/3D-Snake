﻿using System;
using StaticTags;
using UnityEngine;

namespace Player
{
    public class SnakeEating : MonoBehaviour
    {
        public Action OnFoodEaten;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(Tags.Apple))
            {
                Destroy(other.gameObject);
                OnFoodEaten?.Invoke();
            }
        }
    }
}