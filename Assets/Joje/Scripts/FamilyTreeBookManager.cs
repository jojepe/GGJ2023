using System;
using System.Collections.Generic;
using Joje.Scripts;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.SceneManagement;
using SceneReference = Eflatun.SceneReference.SceneReference;

public class FamilyTreeBookManager : MonoBehaviour
{
    [SerializeField] private List<NameInput> nameInputs;
    [SerializeField] private SceneReference victoryScene;

    [Header("GameEvents")]
    [SerializeField] private GameEvent onFamilyTreeEnabled;
    [SerializeField] private GameEvent onFamilyTreeDisabled;
    [SerializeField] private GameEvent onAllNamesFound;
    
    private bool HasAllNamesBeenFound 
        => nameInputs.TrueForAll(n => n.MemoryData.hasNameBeenFound);

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
        
        onAllNamesFound.Raise();
        SceneLoader.Instance.LoadScene(victoryScene.BuildIndex, 5f);
    }
    
}
