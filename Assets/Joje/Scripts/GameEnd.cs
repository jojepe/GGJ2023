using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    public int endTimer;
    
    void Start()
    {
        StartCoroutine(endGame());
    }

    IEnumerator endGame()
    {
        yield return new WaitForSeconds(endTimer);
        print("EndGame");
        Application.Quit();
    }

}
