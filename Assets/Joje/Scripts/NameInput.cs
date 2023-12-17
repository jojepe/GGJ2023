using System.Runtime.InteropServices;
using ScriptableObjectArchitecture;
using TMPro;
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

    private InputField _inputField;
    private string _input;

    public void Start()
    {
        _inputField = inputFieldGameObject.GetComponent<InputField>();
        picture.sprite = MemoryData.representation;

        if (MemoryData.hasNameBeenFound)
        {
           ShowMemory();
        }
        else
        {
            HideMemory();
            if (_inputField == null)
            {
                return;
            }
            _inputField.text = MemoryData.writtenName;
            _inputField.onValueChanged.AddListener(ReadStringInput);
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

    public void HideMemory()
    {
        inputFieldGameObject.SetActive(true);
        picture.gameObject.SetActive(false);
    }

    public void SaveNameToMemory()
    {
        MemoryData.SaveWrittenName(_input);
    }
    
}
