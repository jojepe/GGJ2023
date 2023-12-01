using System;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FamilyTreeBookManager : MonoBehaviour
{
    [SerializeField] private NameInput[] nameInputs;

    [Header("GameEvents")]
    [SerializeField] private GameEvent onFamilyTreeEnabled;
    [SerializeField] private GameEvent onFamilyTreeDisabled;
    
    private bool HasAllNamesBeenFound 
        => Array.TrueForAll(nameInputs, n => n.MemoryData.hasNameBeenFound);

    // protected override void Start()
    // {
    //     base.Start();
    //     Array.ForEach(nameInputs, ResetStatus);
    // }

    private void OnEnable()
    {
        onFamilyTreeEnabled.Raise();
    }

    protected void Start()
    {
        Array.ForEach(nameInputs, ResetStatus);
    }
    
    private void OnDisable()
    {
        onFamilyTreeDisabled.Raise();
    }

    private void ResetStatus(NameInput nameInput)
    {
        nameInput.familyTreeBook = this;
        // nameInput.MemoryData.hasNameBeenFound = false;
    }
    
    public void RightAnswer()
    {
        if (!HasAllNamesBeenFound) return;
        
        print("Win Game");
        SceneManager.LoadScene("WinGame");
    }
    
}
