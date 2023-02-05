using System;
using System.Collections.Generic;
using UnityEngine;

namespace Marlus.InventorySystem.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Inventory", menuName = "ScriptableObjects/Inventory", order = 1)]

    public class Inventory : ScriptableObject
    {
        public List<UsableItem> usableItems;

        public void Add(UsableItem usableItem)
        {
            usableItem._inventory = this;
            usableItems.Add(usableItem);
            usableItem.hasBeenCollected = true;
        }

        public void Remove(UsableItem usableItem)
        {
            usableItems.Remove(usableItem);
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