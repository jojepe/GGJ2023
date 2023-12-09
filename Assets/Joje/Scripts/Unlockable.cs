using Marlus.InventorySystem.Scripts;
using UnityEngine;
using Object = System.Object;

namespace Joje.Scripts
{
    public class Unlockable : MonoBehaviour
    {
        [SerializeField] protected  int interactionIndex;
        protected bool isLocked;

        public void TryUnlockRoom(Object sentUsableItemRepresentation)
        {
            var usableItemRepresentation = (UsableItemRepresentation)sentUsableItemRepresentation;
            var usableItem = usableItemRepresentation.UsableItem;
            if (this.interactionIndex == usableItem.InteractionIndex && isLocked)
            {
                isLocked = false;
                // image.sprite = unlockedIcon;
                if (usableItem.CurrentQuantity > 1)
                {
                    usableItem.ReduceQuantity();
                    usableItemRepresentation.ResetPositionToInventory();
                }
                else
                {
                    Destroy(usableItemRepresentation.gameObject);
                }
            }
            else
            {
                usableItemRepresentation.ResetPositionToInventory();
            }
        }
    }
}