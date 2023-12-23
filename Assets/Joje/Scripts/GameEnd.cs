using System.Collections;
using Joje.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    public int endTimer;
    public bool resetGame;
    
    void Start()
    {
        StartCoroutine(EndGame());
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(endTimer);
        if (resetGame)
        {
            DataManager.Instance.ResetData();
            SceneLoader.Instance.ReloadGame();
            yield break;
        }
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

}