using System;
using DG.Tweening;
using ScriptableObjectArchitecture;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip[] musicSources;
    [SerializeField] private AudioClipGameEvent onSongPlayed;

    private AudioSource _audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        PlayRandomMusic();
    }

    private void PlayRandomMusic()
    {
        if (TryGetComponent(out _audioSource))
        {
            var clip = musicSources[Random.Range(0, musicSources.Length - 1)];
            _audioSource.clip = clip;
            _audioSource.Play();
            Debug.Log("aaa");
            onSongPlayed.Raise(clip);
        }
    }

    public void FadeOut(float time)
    {
        _audioSource.DOFade(0f, time);
    }
}
