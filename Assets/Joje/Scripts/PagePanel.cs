using System;
using System.Collections.Generic;
using System.Linq;
using Marlus.InventorySystem.Scripts;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Joje.Scripts
{
    public class PagePanel : InteractablePanel
    {
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
                refPage.gameObject.SetActive(true);
                refPage.image.SetActive(true);
                // refPage.interactable = true;
                usableItemRep.UsableItem.hasBeenSet = true;
            }
            // usableItemRep.UsableItem._inventory.usableItems.Clear();
            usableItemRep.UsableItem._inventory.Remove(usableItemRep.UsableItem);
            Destroy(usableItemRep.gameObject);
        }
    }
}