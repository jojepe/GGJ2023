using UnityEngine;

namespace Marlus.InventorySystem.Scripts
{
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField] private UsableItemRepresentation[] usableItemSlots;

        private bool IsEmpty(int index) => !usableItemSlots[index].CanBeUsed;

        public void TryInsertItem(Object usableItemGenericObject)
        {
            foreach (var usableItemSlot in usableItemSlots)
            {
                if (!usableItemSlot.CanBeUsed)
                {
                    var usableItemCollectable = (UsableItemCollectable)usableItemGenericObject;
                    usableItemSlot.SetItemProperties(usableItemCollectable.UsableItem);
                    Destroy(usableItemCollectable.gameObject);
                    Debug.Log("aaa");
                    break;
                }
            }
        }
    }
}