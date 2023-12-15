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
    [FormerlySerializedAs("inputField")]
    [Header("Input Field")] 
    [FormerlySerializedAs("field")] [SerializeField] private GameObject inputFieldGameObject;

    [Header("Game Events")] 
    [SerializeField] private StringGameEvent onNameFound;

    private TMP_InputField _inputField;
    private string _input;
    
    public void Start()
    {
        _inputField = inputFieldGameObject.GetComponent<TMP_InputField>();

        if (MemoryData.hasNameBeenFound)
        {
           ShowMemory();
        }
        else
        {
            _inputField.text = MemoryData.writtenName;
        }
    }

    public void ReadStringInput(string s)
    {
        _input = s;
        // print(_input);
        SaveNameToMemory();
        if (MemoryData.name.ToLower().Equals(_input.ToLower()) == false) return;
        
        MemoryData.hasNameBeenFound = true;
        onNameFound.Raise(_input);
        ShowMemory();
    }

    public void ShowMemory()
    {
        inputFieldGameObject.SetActive(false);
        picture.gameObject.SetActive(true);
    }

    public void SaveNameToMemory()
    {
        MemoryData.SaveWrittenName(_input);
    }
}
