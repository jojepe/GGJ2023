using System;
using System.Linq;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Joje.Scripts
{
    public class Door : RoomTransitor
    {
        [SerializeField] public BoolReference[] activationConditions;

        private void OnMouseDown()
        {
            if (this.enabled == false || AreAllConditionsMet() == false) 
            {
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