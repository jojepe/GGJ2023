using System;
using ScriptableObjectArchitecture;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class NameInput : MonoBehaviour
{
    [field: SerializeField] public FamilyMemberMemoryData MemoryData {get; private set;}
    [SerializeField] private Image picture;
    [Header("Input Field")] 
    [FormerlySerializedAs("field")] [SerializeField] private GameObject inputField;

    [Header("Game Events")] 
    [SerializeField] private StringGameEvent onNameFound;
    
    [HideInInspector] public FamilyTreeBookManager familyTreeBook;
    
    private string input;
    
    public void Start()
    {

        if (MemoryData.hasNameBeenFound)
        {
           ShowMemory();
        }
    }

    public void ReadStringInput(string s)
    {
        input = s;
        // print(input);
        if (MemoryData.name.ToLower().Equals(input.ToLower()) == false) return;
        
        // inputField.SetActive(false);
        // picture.gameObject.SetActive(true);
        MemoryData.hasNameBeenFound = true;
        onNameFound.Raise(input);
        ShowMemory();
    }

    public void ShowMemory()
    {
        inputField.SetActive(false);
        picture.gameObject.SetActive(true);
    }
}
