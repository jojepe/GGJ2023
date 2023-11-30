using Unity.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class NameInput : MonoBehaviour
{
    [field: SerializeField] public FamilyMemberMemoryData MemoryData {get; private set;}
    [SerializeField] private Image picture;
    [FormerlySerializedAs("field")]
    [Header("Input Field")] 
    [SerializeField] private GameObject inputField;
    
    [HideInInspector] public FamilyTreeBookManager familyTreeBook;
    
    private string input;

    public void Start()
    {
        if (MemoryData.hasNameBeenFound)
        {
            ReadStringInput(MemoryData.name);
            return;
        }

        MemoryData.hasNameBeenFound = false;
    }

    public void ReadStringInput(string s)
    {
        input = s;
        print(input);
        if (MemoryData.name.ToLower().Equals(input.ToLower()) == false) return;
        
        inputField.SetActive(false);
        picture.gameObject.SetActive(true);
        MemoryData.hasNameBeenFound = true;
        // familyTreeBook.RightAnswer();
    }
}
