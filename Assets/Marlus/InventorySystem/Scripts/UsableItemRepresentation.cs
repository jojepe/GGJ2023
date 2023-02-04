using ScriptableObjectArchitecture;
using UnityEngine;

namespace Marlus.InventorySystem.Scripts
{
    public class UsableItemRepresentation : MonoBehaviour
    {
        public UsableItem usableItem;
        public IntGameEvent OnTryUseItem;

        public void TryUseItem()
        {
            OnTryUseItem.Raise(usableItem.InteractionIndex);
        }

    }
}