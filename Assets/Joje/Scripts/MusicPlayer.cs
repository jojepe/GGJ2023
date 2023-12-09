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
        
        PlayRandomMusic();
    }

    private void PlayRandomMusic()
    {
        if (TryGetComponent(out _audioSource))
        {
            // PlayerPrefs.SetInt("LastPlayedSong", );
            var clip = musicSources[Random.Range(0, musicSources.Length - 1)];
            _audioSource.clip = clip;
            _audioSource.Play();
            onSongPlayed.Raise(clip);
        }
    }
}
