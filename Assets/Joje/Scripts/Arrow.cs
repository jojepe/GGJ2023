using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Arrow : MonoBehaviour
{
    public bool isLocked;
    public string roomToEnter;
    
    public void EnterRoom()
    {
        if (!isLocked)
        {
            SceneManager.LoadScene(roomToEnter);
            print("Entered " + roomToEnter);
        }
        else
        {
            print(roomToEnter + " is Locked");
        }
    }

}
