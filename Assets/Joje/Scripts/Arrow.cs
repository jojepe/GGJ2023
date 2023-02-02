using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Arrow : MonoBehaviour
{
    public void Room1()
    {
        SceneManager.LoadScene("Quarto1");
        print("Entered Room 1");
    }
    
    public void Room2()
    {
        SceneManager.LoadScene("Quarto2");
        print("Entered Room 2");
    }
    
    public void Room3()
    {
        SceneManager.LoadScene("Quarto3");
        print("Entered Room 3");
    }
    
    public void Room4()
    {
        SceneManager.LoadScene("Quarto4");
        print("Entered Room 4");
    }
}
