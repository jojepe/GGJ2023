using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Joje.Scripts
{
    public class RandomSoundPlayer : MonoBehaviour
    {
        [SerializeField] private AudioClip[] audioClips;

        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlayRandomAudio()
        { 
            // PlayerPrefs.SetInt("LastPlayedSong", );
            var clip = audioClips[Random.Range(0, audioClips.Length - 1)];
            _audioSource.clip = clip;
            AudioSource.PlayClipAtPoint(clip, Vector3.zero); 
        }    
    }
}