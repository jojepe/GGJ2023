using Joje.Scripts;
using Marlus.InventorySystem.Scripts;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Object = UnityEngine.Object;
using SceneReference = Eflatun.SceneReference.SceneReference;

[RequireComponent(typeof(Image))]
public class Arrow : RoomTransitor
{
    [SerializeField] private Sprite lockedIcon;
    [SerializeField] private Sprite unlockedIcon;
    private Image image;

    private void Start()
    {
        if (TryGetComponent(out image))
        {
            image.sprite = isLocked ? lockedIcon : unlockedIcon;
        }
    }
}
