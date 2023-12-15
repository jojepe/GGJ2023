using UnityEngine;

[CreateAssetMenu(fileName = "FamilyMemberMemoryData", menuName = "ScriptableObjects/FamilyMemberMemoryData", order = 1)]
public class FamilyMemberMemoryData : ScriptableObject
{
    public string name;
    public string defaultWrittenName;
    public string writtenName;
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
        writtenName = defaultWrittenName;
        hasNameBeenFound = false;
    }

    public void SaveWrittenName(string writtenName)
    {
        this.writtenName = writtenName;
    }
}
