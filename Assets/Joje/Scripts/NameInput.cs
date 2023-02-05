using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NameInput : MonoBehaviour
{
    [Header("Family Member")]
    public string name;
    public Image picture;
    [Header("Input Field")] 
    public GameObject field;
    public Book book;
    
    private string input;

    public void ReadStringInput(string s)
    {
        input = s;
        print(input);
        if (name.ToLower().Equals(input.ToLower()))
        {
            field.SetActive(false);
            print("Disable Image");
            picture.gameObject.SetActive(true);
            book.rightAwnser();
        }
    }
}
