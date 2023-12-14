using System;
using Joje.Scripts;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.SceneManagement;
using SceneReference = Eflatun.SceneReference.SceneReference;

public class TimerHolder : MonoBehaviour
{
    [SerializeField] private GameObject parentUI;
    [SerializeField] private float durationMultiplier;
    [SerializeField] private float offsetTime = 5f;
    [SerializeField] private SceneReference endGameScene;
    [SerializeField] private FloatGameEvent onTimeUpdated;
    [SerializeField] private GameEvent onTimeEnded;
    
    private float targetTime;
    private float timer = 0;

    private void Awake()
    {
        DontDestroyOnLoad(parentUI);
    }

    void Update()
    {
        if (targetTime <= 0)
        {
            return;
        }
        timer += Time.deltaTime;
        onTimeUpdated.Raise(1-timer/targetTime);

        if (timer > targetTime - offsetTime && SceneLoader.Instance.IsLoading == false)
        {
            print("No more time");
            onTimeEnded.Raise();
            SceneLoader.Instance.LoadScene(endGameScene.BuildIndex, offsetTime, 
                () => gameObject.SetActive(false));
        }
    }

    public void SetTargetTime(AudioClip audioClip)
    {
        // Debug.Log("Duration: " + audioClip.length);
        targetTime = audioClip.length * durationMultiplier;
    }
}
