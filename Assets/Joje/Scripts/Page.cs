using Marlus.InventorySystem.Scripts;
using UnityEngine;
using UnityEngine.EventSystems;

public class Page : MonoBehaviour, IDragHandler, ISelectHandler, IDeselectHandler, IPointerDownHandler
{
    public UsableItem usableItem;
    public GameObject image;
    public GameObject buttons;
    [Header("ScreenLimit")] 
    public int maxX;
    public int minX;
    public int maxY;
    public int minY;
    private RectTransform draggingObject;

    private void Awake()
    {
        draggingObject = transform as RectTransform;
        image.SetActive(usableItem.hasBeenSet ? true : false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(draggingObject, eventData.position,
                eventData.pressEventCamera, out var globalMousePosition))
        {
            if (globalMousePosition.x > maxX || globalMousePosition.x < minX || globalMousePosition.y > maxY || globalMousePosition.y < minY)
            {
                return;
            }
            draggingObject.position = globalMousePosition;
            print(draggingObject.position);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left)
            return;
        EventSystem.current.SetSelectedGameObject(gameObject, eventData);
    }

    public void OnSelect(BaseEventData eventData)
    {
        if (image.activeSelf == true)
        {
            buttons.SetActive(true);
        }
    }
    
    public void OnDeselect(BaseEventData eventData)
    {
        buttons.SetActive(false);
    }
    
    public void rotateRight()
    {
        image.transform.eulerAngles += new Vector3(0,0,-22.5f);
    }

    public void rotateLeft()
    {
        image.transform.eulerAngles += new Vector3(0,0,22.5f);
    }

    public void TryShow(Object _object)
    {
        var message = (UsableItemRepresentation)_object;
        if (message.UsableItem.InteractionIndex == usableItem.InteractionIndex)
        {
            image.SetActive(true);
            message.UsableItem.hasBeenSet = true;
        }
        message.UsableItem._inventory.usableItems.Clear();
        Destroy(message.gameObject);
    }
    
}
