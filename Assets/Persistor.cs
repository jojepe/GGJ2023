using System;
using UnityEngine;

public class Persistor : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(this);
    }
}
