using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Book : MonoBehaviour
{
    public int nameNumbers;
    public static int correctNames;
    void Start()
    {
        correctNames = nameNumbers;
    }

    // Update is called once per frame
    void Update()
    {
        if (correctNames == 0)
        {
            print("Win Game");
            SceneManager.LoadScene("WinGame");
        }
    }

    public void rightAwnser()
    {
        correctNames--;
        print(correctNames + " names left.");
    }
    
}
