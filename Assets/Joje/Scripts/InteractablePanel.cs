using System;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Joje.Scripts
{
    public class InteractablePanel : MonoBehaviour
    {
        [SerializeField] private GameEvent onInteractablePanelEnabled;
        [SerializeField] private GameEvent onInteractablePanelDisabled;

        private void OnEnable()
        {
            onInteractablePanelEnabled.Raise();
        }

        private void OnDisable()
        {
            onInteractablePanelDisabled.Raise();
        }
    }
}