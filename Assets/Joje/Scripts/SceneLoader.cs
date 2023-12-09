using System;
using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Joje.Scripts
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private SceneReference mainScene;

        private void Awake()
        { 
            LoadMainScene();
        }

        private void LoadMainScene()
        {
            if ( mainScene.LoadedScene.isLoaded)
            {
                return;
            }
            SceneManager.LoadScene(mainScene.BuildIndex, LoadSceneMode.Additive);
        }
    }
}