using System;
using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Joje.Scripts
{
    public class SceneLoader : Singleton<SceneLoader>
    {
        [SerializeField] private SceneReference mainScene;
        
        [SerializeField] private float defaultLoadTime;

        protected override void Awake()
        { 
            base.Awake();
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