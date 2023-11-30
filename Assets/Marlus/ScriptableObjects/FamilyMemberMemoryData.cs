using UnityEngine;

[CreateAssetMenu(fileName = "FamilyMemberMemoryData", menuName = "ScriptableObjects/FamilyMemberMemoryData", order = 1)]
public class FamilyMemberMemoryData : ScriptableObject
{
    public string name;
    [HideInInspector] public bool hasNameBeenFound;
}
