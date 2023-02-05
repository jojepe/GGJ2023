using System;
using UnityEngine;

namespace Marlus.InventorySystem.Scripts
{
    public class TargetMover : MonoBehaviour
    {
        [SerializeField] private Transform target;
        private Vector3 originalPosition;
        private bool isOnTarget;

        private void Start()
        {
            originalPosition = transform.position;

            if (isOnTarget)
            {
                Move();
            }
        }

        public void Move()
        {
            if (isOnTarget)
            {
                transform.position = originalPosition;
                isOnTarget = false;
                return;
            }
            transform.position = target.position;
            isOnTarget = true;
        }
    }
}