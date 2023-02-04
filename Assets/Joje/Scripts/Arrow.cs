using System.Collections;
using System.Collections.Generic;
using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Arrow : MonoBehaviour
{
    public bool isLocked;
    public SceneReference roomToEnter;
    public int interactionIndex;
    
    public void EnterRoom()
    {
        if (!isLocked)
        {
            SceneManager.LoadScene(roomToEnter.BuildIndex);
            print("Entered " + roomToEnter);
        }
        else
        {
            print(roomToEnter + " is Locked");
        }
    }

    public void TryUnlockRoom(int interactionIndex)
    {
        if (this.interactionIndex == interactionIndex)
        {
            isLocked = false;
            print($"The door which index is: {this.interactionIndex} has been unlocked");
            print("It´s name is: " + gameObject.name);
        }
    }

}
