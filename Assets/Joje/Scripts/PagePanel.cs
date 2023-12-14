﻿using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Marlus.InventorySystem.Scripts;
using ScriptableObjectArchitecture;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Joje.Scripts
{
    public class PagePanel : InteractablePanel
    {
        [SerializeField] [CanBeNull] private GameEvent OnUsableItemUsed;
        
        private List<Page> pages;
        private Page refPage;

        private void Awake()
        {
            // gameObject.SetActive(false);
        }

        private void Start()
        {
            InitializePages();
        }

        private void InitializePages()
        {
            pages = new List<Page>(transform.childCount);
            
            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).TryGetComponent(out refPage) == false) continue;
                
                pages.Add(refPage);
                refPage.gameObject.SetActive(refPage.usableItem.hasBeenSet);
            }
        }
        
        public void TryShowUsableItem(Object _object)
        {
            var usableItemRep = (UsableItemRepresentation)_object;

            refPage = pages.FirstOrDefault(p =>
                usableItemRep.UsableItem.InteractionIndex == p.usableItem.InteractionIndex);

            if (refPage != null)
            {
                usableItemRep.UsableItem.hasBeenSet = true;
                refPage.gameObject.SetActive(true);
                refPage.image.SetActive(true);
                // refPage.interactable = true;
            }
            // usableItemRep.UsableItem._inventory.usableItems.Clear();
            OnUsableItemUsed?.Raise();
            usableItemRep.UsableItem._inventory.Remove(usableItemRep.UsableItem);
            Destroy(usableItemRep.gameObject);
        }
    }
}