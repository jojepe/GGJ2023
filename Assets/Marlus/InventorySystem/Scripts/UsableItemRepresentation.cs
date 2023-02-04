using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.UI;

namespace Marlus.InventorySystem.Scripts
{
    [RequireComponent(typeof(Image))]
    public class UsableItemRepresentation : MonoBehaviour
    {
        public UsableItem usableItem;
        public IntGameEvent OnTryUseItem;

        private Image image;

        private void Start()
        {
            if (TryGetComponent(out image))
            {
                if (usableItem != null)
                {
                    image.sprite = usableItem.Icon;
                }
            }
        }

        public void TryUseItem()
        {
            OnTryUseItem.Raise(usableItem.InteractionIndex);
        }

    }
}