using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Joje.Scripts
{
    public class RoomTransitor : Unlockable
    {
        public SceneReference roomToEnter;

        protected AudioSource _audioSource;
        public AudioSource AudioSource 
            => _audioSource != null ? _audioSource : GetComponent<AudioSource>();

        public void EnterRoom()
        {
            if (!isLocked)
            {
                if (SceneLoader.Instance.IsLoading)
                {
                    return;
                }
                // SceneManager.LoadScene(roomToEnter.BuildIndex);
                AudioSource.Play();
                SceneLoader.Instance.LoadScene(roomToEnter.BuildIndex);
                print("Entered " + roomToEnter);
            }
            else
            {
                print(roomToEnter + " is Locked");
            }
        }
    }
}