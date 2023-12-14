using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Joje.Scripts
{
    public class DelayedImageFader : MonoBehaviour, IFader
    {
        [SerializeField] private Image image;
        [SerializeField] private float fadeDelay;
        [SerializeField] private float fadeDuration;
        [SerializeField] private bool fadeOnStart;

        private void Start()
        {
            if (fadeOnStart)
            {
                StartCoroutine(FadeCoroutine());
            }
        }

        public IEnumerator FadeCoroutine()
        {
            yield return new WaitForSeconds(fadeDelay);
            image.DOFade(1f, fadeDuration);
        }
    }
}