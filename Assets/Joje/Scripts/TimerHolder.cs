using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerHolder : MonoBehaviour
{
    [Header("Time to End")] 
    public float time;
    
    [Header("Timer")]
    [SerializeField]
    private float timer = 0;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > time)
        {
            print("No more time");
            SceneManager.LoadScene("EndGame");
            gameObject.SetActive(false);
        }
    }
}
