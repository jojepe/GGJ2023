using System;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerHolder : MonoBehaviour
{
    [SerializeField] private float targetTime;
    [SerializeField] private FloatGameEvent onTimeUpdated;
    [SerializeField] private GameObject parentUI;
    
    private float timer = 0;

    private void Awake()
    {
        DontDestroyOnLoad(parentUI);
    }

    void Update()
    {
        timer += Time.deltaTime;
        onTimeUpdated.Raise(1-timer/targetTime);

        if (timer > targetTime)
        {
            print("No more time");
            SceneManager.LoadScene("EndGame");
            gameObject.SetActive(false);
        }
    }
}
