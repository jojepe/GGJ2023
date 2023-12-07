using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitTimer : MonoBehaviour
{
    [SerializeField] private float quitDelayInSeconds;
    [SerializeField] private bool quitOnStart;

    private void Start()
    {
        if (quitOnStart)
        {
            StartCoroutine(timedQuit());
        }
    }


    private IEnumerator timedQuit()
    {
        yield return new WaitForSecondsRealtime(quitDelayInSeconds);
        Application.Quit();
    }
}
