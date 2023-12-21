using System;
using System.Linq;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Joje.Scripts
{
    public class Door : RoomTransitor, IPointerDownHandler
    {
        [SerializeField] public BoolReference[] activationConditions;

        public void OnPointerDown(PointerEventData eventData)
        {
            if (this.enabled == false || AreAllConditionsMet() == false) 
            {
                Debug.Log("aaa");
                return;
            }
            EnterRoom();
        }

        private bool AreAllConditionsMet()
        {
            return activationConditions.Length <= 0 || Array.TrueForAll(activationConditions, c => c.Value);
        }
    }
}