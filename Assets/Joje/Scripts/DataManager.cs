using System.Collections.Generic;
using Marlus.InventorySystem.ScriptableObjects;
using UnityEngine;

namespace Joje.Scripts
{
    public class DataManager : Singleton<DataManager>
    {
        [SerializeField] private List<UsableItem> usableItems;
        [SerializeField] private List<FamilyMemberMemoryData> familyMemories;
        [SerializeField] private List<Inventory> inventories;

        public void ResetData()
        {
            usableItems.ForEach(u => u.Reset());
            familyMemories.ForEach(m => m.Reset());
            inventories.ForEach(i => i.usableItems.Clear());
        }
    }
}