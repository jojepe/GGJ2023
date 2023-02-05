using System;
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

        private void Start()
        {
            usableItems = new GameObject[usableItemSlots.Length];
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
                    Destroy(usableItemCollectable.gameObject);
                    break;
                }
            }
        }
    }
}