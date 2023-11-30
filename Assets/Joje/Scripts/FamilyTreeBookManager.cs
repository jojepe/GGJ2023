using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FamilyTreeBookManager : Persistor
{
    [SerializeField] private NameInput[] nameInputs;
    
    private bool HasAllNamesBeenFound 
        => Array.TrueForAll(nameInputs, n => n.MemoryData.hasNameBeenFound);

    protected override void Start()
    {
        base.Start();
        Array.ForEach(nameInputs, ResetStatus);
    }

    private void ResetStatus(NameInput nameInput)
    {
        nameInput.familyTreeBook = this;
        nameInput.MemoryData.hasNameBeenFound = false;
    }
    
    public void RightAnswer()
    {
        if (!HasAllNamesBeenFound) return;
        
        print("Win Game");
        SceneManager.LoadScene("WinGame");
    }
    
}
