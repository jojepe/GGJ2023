using System;
using UnityEngine;

[CreateAssetMenu(fileName = "FamilyMemberMemoryData", menuName = "ScriptableObjects/FamilyMemberMemoryData", order = 1)]
public class FamilyMemberMemoryData : ScriptableObject
{
    public string name;
    [SerializeField] private bool _hasNameBeenFound;

    public bool hasNameBeenFound
    {
        get => _hasNameBeenFound;
        set
        {
            // Debug.Log($"{name} has been found = {value}");
            _hasNameBeenFound = value;
        }
    }

    private void Awake()
    {
        hideFlags = HideFlags.DontUnloadUnusedAsset;
    }

    private void OnDisable()
    {
        hasNameBeenFound = false;
    }
}
