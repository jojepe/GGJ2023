using System.Collections;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    public int endTimer;
    
    void Start()
    {
        StartCoroutine(EndGame());
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(endTimer);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

}
