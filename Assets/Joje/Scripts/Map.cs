using System;
using System.Collections;
using System.Collections.Generic;
using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour
{
    [Header("Pins")] 
    public GameObject[] pins;

    [Header("Scenes")] 
    public SceneReference[] roomScenes;
    
    private void Start()
    {
        Scene scene = SceneManager.GetActiveScene();

        for (int i = 0; i < pins.Length; i++)
        {
            pins[i].SetActive(false);
        }

        for (int j = 0; j < roomScenes.Length; j++)
        {
            print(scene.buildIndex);
            if (scene.buildIndex == roomScenes[j].BuildIndex)
            {
                print(scene.name);
                pins[j].SetActive(true);
            }
        }
    }
}
