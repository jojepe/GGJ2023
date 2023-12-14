using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Joje.Scripts
{
    [RequireComponent(typeof(AudioSource))]
    public class InstantAudioPlayer : MonoBehaviour, IFader
    {
        [SerializeField] private float targetVolume;
        [SerializeField] private float fadeInTime;
        [SerializeField] private float fadeOutOffset;
        [SerializeField] private float fadeOutTime;

        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            StartCoroutine(FadeCoroutine());
        }

        public IEnumerator FadeCoroutine()
        {
            _audioSource.volume = 0f;
            _audioSource.Play();
            _audioSource.DOFade(targetVolume, fadeInTime);
            yield return new WaitForSeconds(fadeOutOffset);
            _audioSource.DOFade(0f, fadeOutTime);
        }
    }
}