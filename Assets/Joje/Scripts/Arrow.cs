using Marlus.InventorySystem.Scripts;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Object = UnityEngine.Object;
using SceneReference = Eflatun.SceneReference.SceneReference;

[RequireComponent(typeof(Image))]
public class Arrow : MonoBehaviour
{
    [Header("VISUAL REPRESENTATION")] 
    [SerializeField] private Sprite lockedIcon;
    [SerializeField] private Sprite unlockedIcon;
    private Image image;
    
    [Header("INTERACTION SETUP")]
    public bool isLocked;
    public SceneReference roomToEnter;
    public int interactionIndex;
    public ObjectGameEvent OnRoomUnlocked;
    
    private void Start()
    {
        if (TryGetComponent(out image))
        {
            image.sprite = isLocked ? lockedIcon : unlockedIcon;
        }
    }

    public void EnterRoom()
    {
        if (!isLocked)
        {
            SceneManager.LoadScene(roomToEnter.BuildIndex);
            print("Entered " + roomToEnter);
        }
        else
        {
            print(roomToEnter + " is Locked");
        }
    }

    public void TryUnlockRoom(Object sentUsableItemRepresentation)
    {
        var usableItemRepresentation = (UsableItemRepresentation)sentUsableItemRepresentation;
        var usableItem = usableItemRepresentation.UsableItem;
        if (this.interactionIndex == usableItem.InteractionIndex && isLocked)
        {
            isLocked = false;
            OnRoomUnlocked.Raise();
            image.sprite = unlockedIcon;
            if (usableItem.CurrentQuantity > 1)
            {
                usableItem.ReduceQuantity();
                usableItemRepresentation.ResetPositionToInventory();
            }
            else
            {
                Destroy(usableItemRepresentation.gameObject);
            }
        }
        else
        {
            usableItemRepresentation.ResetPositionToInventory();
        }
    }

}
