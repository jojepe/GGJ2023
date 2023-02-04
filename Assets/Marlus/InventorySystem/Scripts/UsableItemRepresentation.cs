using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.UI;

namespace Marlus.InventorySystem.Scripts
{
    [RequireComponent(typeof(Image))]
    public class UsableItemRepresentation : MonoBehaviour
    {
        public IntGameEvent OnTryUseItem;

        private UsableItem usableItem;
        private Image image;

        public bool CanBeUsed => usableItem != null && image.sprite != null; 
        private void Start()
        {
            if (TryGetComponent(out image))
            {
                SetVisuals();
            }
        }

        public void SetItemProperties(UsableItem usableItem)
        {
            this.usableItem = usableItem;
            SetVisuals();
        }

        private void SetVisuals()
        {
            if (usableItem != null)
            {
                image.enabled = true;
                image.sprite = usableItem.Icon;
            }
            else
            {
                image.sprite = null;
                image.enabled = false;
            }
        }

        public void TryUseItem()
        {
            OnTryUseItem.Raise(usableItem.InteractionIndex);
        }

    }
}