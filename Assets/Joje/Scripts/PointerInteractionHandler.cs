using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Joje.Scripts
{
    public class PointerInteractionHandler : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private GameEvent onPointerDown;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            if (enabled == false)
            {
                return;
            }
            onPointerDown.Raise();
        }
    }
}