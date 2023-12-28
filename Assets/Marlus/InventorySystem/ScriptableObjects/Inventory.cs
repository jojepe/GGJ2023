using System;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Marlus.InventorySystem.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Inventory", menuName = "ScriptableObjects/Inventory", order = 1)]

    public class Inventory : ScriptableObject
    {
        public List<UsableItem> usableItems;
        [SerializeField] private int maximumItems;

        [Header("Variable References")] 
        [SerializeField] private BoolReference hasReachedLimit;
        [SerializeField] private BoolReference hasSpace;

        [Header("Game Events")] 
        [SerializeField] public GameEvent onLimitReached;
        [SerializeField] public GameEvent onLimitCleared;
        // [SerializeField] public IntGameEvent onItemAdded;
        // [SerializeField] public IntGameEvent onItemRemoved;

        public bool IsFull => usableItems.Count >= maximumItems;

        public void Add(UsableItem usableItem)
        {
            if (IsFull)
            {
                Debug.Log("INVENTORY IS FULL");
                return;
            }   
            usableItem._inventory = this;
            usableItems.Add(usableItem);
            usableItem.hasBeenCollected = true;
            if (IsFull)
            {
                // Debug.Log("LIMIT REACHED!");
                hasReachedLimit.Value = true;
                onLimitReached.Raise();
                hasSpace.Value = false;

            }
        }

        public void Remove(UsableItem usableItem)
        {
            if (IsFull)
            {
                // Debug.Log("LIMIT CLEARED!");
                onLimitCleared.Raise();
                hasReachedLimit.Value = false;
            }
            usableItem._inventory = null;
            usableItems.Remove(usableItem);
            // usableItem.hasBeenCollected = false;
            hasSpace.Value = true;
        }

        public void OnEnable()
        {
            usableItems.Clear();
        }
        
        public void OnDisable()
        {
            usableItems.Clear();
        }
    }
}