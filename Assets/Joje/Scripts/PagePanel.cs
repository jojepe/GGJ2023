using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using JetBrains.Annotations;
using Marlus.InventorySystem.Scripts;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Joje.Scripts
{
    public class PagePanel : InteractablePanel
    {
        [SerializeField] [CanBeNull] private GameEvent OnUsableItemUsed;
        [SerializeField] private float fadeDuration;
        
        private List<Page> pages;
        private Page refPage;
        private Sequence fadeSequence;

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
            fadeSequence = DOTween.Sequence();
            var usableItemRep = (UsableItemRepresentation)_object;

            
            refPage = pages.FirstOrDefault(p =>
                usableItemRep.UsableItem.InteractionIndex == p.usableItem.InteractionIndex);

            if (refPage != null)
            {
                fadeSequence.Append(usableItemRep.image.DOFade(0f, fadeDuration));

                fadeSequence.onComplete += () => usableItemRep.UsableItem.hasBeenSet = true;
                refPage.gameObject.SetActive(true);
                refPage.image.SetActive(true);
                if (refPage.image.TryGetComponent(out Image image))
                {
                    Color color = image.color;
                    color.a = 0f;
                    image.color = color;
                    fadeSequence.Join(image.DOFade(1f, fadeDuration));
                }
            }
            fadeSequence.onComplete += () => OnUsableItemUsed?.Raise();
            fadeSequence.onComplete += () => usableItemRep.UsableItem._inventory.Remove(usableItemRep.UsableItem);
            fadeSequence.onComplete += () => Destroy(usableItemRep.gameObject);
            fadeSequence.Play();
        }
    }
}