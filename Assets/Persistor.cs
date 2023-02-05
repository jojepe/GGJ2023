using System;
using UnityEngine;

public class Persistor : MonoBehaviour
{
    private static bool exists = false;

    private void Start()
    {
        if (exists)
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(this);
        exists = true;
    }
}
