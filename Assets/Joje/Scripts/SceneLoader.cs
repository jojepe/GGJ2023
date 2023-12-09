using System;
using DG.Tweening;
using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Joje.Scripts
{
    public class SceneLoader : Singleton<SceneLoader>
    {
        [SerializeField] private SceneReference mainScene;
        [SerializeField] private Image loadingBackground;
        [SerializeField] private float defaultExitTime;
        [SerializeField] private float defaultEnterTime;

        private Sequence sceneLoadingSequence;

        protected override void Awake()
        { 
            base.Awake();
            LoadMainScene();
        }

        public void LoadMainScene()
        {
           LoadScene(mainScene.BuildIndex, 0f);
        }

        public void LoadScene(int sceneIndex, float? loadingTime = null, Action sceneLoadedAction = null)
        {
            if (IsLoading)
            {
                Debug.LogWarning("Another scene is already loading!");
                return;
            }
            
            Scene scene = SceneManager.GetSceneByBuildIndex(sceneIndex); 
            if (scene.isLoaded)
            {
                Debug.LogWarning($"{scene.name} scene is already loaded!");
                return;
            }
            
            if (loadingTime.HasValue == false)
                loadingTime = defaultExitTime;
            
            sceneLoadingSequence = DOTween.Sequence();
            sceneLoadingSequence.Append(loadingBackground.DOFade(1f, loadingTime.Value));
            sceneLoadingSequence.AppendCallback(() => SceneManager.LoadScene(sceneIndex));
            if (sceneLoadedAction != null)
            {
                sceneLoadingSequence.AppendCallback(sceneLoadedAction.Invoke);
            }
            sceneLoadingSequence.Append(loadingBackground.DOFade(0f, defaultEnterTime));
            sceneLoadingSequence.Play();
        }

        public void LoadScene(string sceneName, float? loadingTime = null)
            => LoadScene(SceneManager.GetSceneByName(sceneName).buildIndex, loadingTime);

        public bool IsLoading => sceneLoadingSequence.IsActive() &&  sceneLoadingSequence.IsPlaying();
    }
}