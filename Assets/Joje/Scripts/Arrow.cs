using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using SceneReference = Eflatun.SceneReference.SceneReference;

[RequireComponent(typeof(Image))]
public class Arrow : MonoBehaviour
{
    [Header("VISUAL REPRESENTATION")] 
    [SerializeField] private Sprite lockedIcon;
    [SerializeField] private Sprite unlockedIcon;
    private Image image;
    
    [Header("INTERACTION SETUP")]
    public bool isLocked;
    public SceneReference roomToEnter;
    public int interactionIndex;
    
    private void Start()
    {
        if (TryGetComponent(out image))
        {
            image.sprite = isLocked ? lockedIcon : unlockedIcon;
        }
    }

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
            image.sprite = unlockedIcon;
            print($"The door which index is: {this.interactionIndex} has been unlocked");
            print("It´s name is: " + gameObject.name);
        }
    }

}
