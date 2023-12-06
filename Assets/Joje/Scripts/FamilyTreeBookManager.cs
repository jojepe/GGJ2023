using System;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FamilyTreeBookManager : MonoBehaviour
{
    [SerializeField] private List<NameInput> nameInputs;

    [Header("GameEvents")]
    [SerializeField] private GameEvent onFamilyTreeEnabled;
    [SerializeField] private GameEvent onFamilyTreeDisabled;
    
    private bool HasAllNamesBeenFound 
        => nameInputs.TrueForAll(n => n.MemoryData.hasNameBeenFound);

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
        Initialize();
    }
    
    private void OnDisable()
    {
        onFamilyTreeDisabled.Raise();
    }

    private void Initialize()
    {
        nameInputs = new List<NameInput>(transform.childCount);

        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).TryGetComponent(out NameInput nameInput) == false) continue;
                
            nameInputs.Add(nameInput);
            // nameInput.gameObject.SetActive(refPage.usableItem.hasBeenSet);
        }
    }

    public void RightAnswer()
    {
        if (!HasAllNamesBeenFound) return;
        
        print("Win Game");
        SceneManager.LoadScene("WinGame");
    }
    
}
