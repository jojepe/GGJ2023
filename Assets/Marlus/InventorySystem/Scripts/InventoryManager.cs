using System;
using Marlus.InventorySystem.ScriptableObjects;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.Serialization;
using Object = UnityEngine.Object;

namespace Marlus.InventorySystem.Scripts
{
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField] private Transform[] usableItemSlots;
        private GameObject[] usableItems;
        [SerializeField] private GameObject usableItemPrefab;
        [SerializeField] private Inventory inventory;

        private void Start()
        {
            
            usableItems = new GameObject[usableItemSlots.Length];
            PopulateManager();
        }

        public void TryInsertItem(Object usableItemGenericObject)
        {
            for (int i = 0; i < usableItemSlots.Length; i++)
            {
                var usableItem = usableItems[i];
                var usableItemSlot = usableItemSlots[i];
                if (usableItemSlot.childCount == 0)
                {
                    var usableItemCollectable = (UsableItemCollectable)usableItemGenericObject;
                    usableItem = Instantiate(usableItemPrefab, usableItemSlot, false);
                    if (usableItem.TryGetComponent(out UsableItemRepresentation item))
                    {
                        item.SetItemProperties(usableItemCollectable.UsableItem);
                    }

                    inventory.usableItems.Add(usableItemCollectable.UsableItem);
                    Destroy(usableItemCollectable.gameObject);
                    break;
                }
            }
        }

        // public void PopulateManager()
        // {
        //     for (int i = 0; i < usableItemSlots.Length; i++)
        //     {
        //         var usableItem = usableItems[i];
        //         var usableItemSlot = usableItemSlots[i];
        //         if (inventory.usableItems.Count == 0)
        //         {
        //             return;
        //         }
        //         if (usableItemSlot.childCount == 0 && inventory.usableItems[i] != null)
        //         {
        //             usableItem = Instantiate(usableItemPrefab, usableItemSlot, false);
        //             if (usableItem.TryGetComponent(out UsableItemRepresentation item))
        //             {
        //                 item.SetItemProperties(inventory.usableItems[i]);
        //             }
        //             break;
        //         }
        //
        //         print("There's children in: " + gameObject.name);
        //     }
        // }

        public void PopulateManager()
        {
            for (int i = 0; i < inventory.usableItems.Count; i++)
            {
                if (i >= usableItemSlots.Length)
                {
                    return;
                }
                var usableItemSlot = usableItemSlots[i];
                if (usableItemSlot.childCount != 0)
                {
                    continue;
                }
                var usableItemGameObject = Instantiate(usableItemPrefab, usableItemSlot, false);
                if (usableItemGameObject.TryGetComponent(out UsableItemRepresentation item))
                {
                    item.SetItemProperties(inventory.usableItems[i]);
                }
                break;

            }
        }


    }
}