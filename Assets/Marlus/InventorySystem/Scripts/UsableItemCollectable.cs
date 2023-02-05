using ScriptableObjectArchitecture;
using UnityEngine;

public class UsableItemCollectable : MonoBehaviour
{
    [SerializeField] private UsableItem usableItem;
    [SerializeField] private ObjectGameEvent OnUsableItemCollected;
    private Renderer renderer;

    public UsableItem UsableItem => usableItem;

    private void Start()
    {
        if (usableItem.hasBeenCollected)
        {
            Destroy(this.gameObject);
        }
        if (TryGetComponent(out renderer))
        {
            SetIcon();
        }
    }

    private void OnMouseDown()
    {
        OnUsableItemCollected.Raise(this);
    }

    private void SetIcon()
    {
        renderer.material.mainTexture = usableItem.Icon.texture;
    }
    
    
}
