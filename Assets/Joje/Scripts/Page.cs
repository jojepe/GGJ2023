using Marlus.InventorySystem.Scripts;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Page : Selectable, IDragHandler, ISelectHandler, IDeselectHandler, IPointerDownHandler
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
    private Vector3 targetPosition;
    
    private const float rotationRate = 22.5f;

    protected override void Awake()
    {
        draggingObject = transform as RectTransform;
        // interactable = false;
        image.SetActive(usableItem.hasBeenSet ? true : false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (image.activeSelf == false)
        {
            return;
        }
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(draggingObject, eventData.position,
                eventData.pressEventCamera, out var globalMousePosition) == false)
        {
            return;
        }
        if (globalMousePosition.x > maxX || globalMousePosition.x < minX || globalMousePosition.y > maxY || globalMousePosition.y < minY)
        {
            return;
        }
        var targetPosition = globalMousePosition;
        // targetPosition.z = 1f;
        draggingObject.position = targetPosition;
        // print(draggingObject.position);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Pointer down on: " + gameObject.name);
        if (eventData.button != PointerEventData.InputButton.Left)
            return;
        if (image.activeSelf == false || interactable == false)
        {
            // Debug.Log(name + " has been set as last sibling");
            return;
        }
        Debug.Log(gameObject.name + " should be selected");
        EventSystem.current.SetSelectedGameObject(gameObject, eventData);
    }

    public override void OnSelect(BaseEventData eventData)
    {
        if (image.activeSelf == true)
        {
            // Debug.Log("Rotation button toggled on");
            buttons.SetActive(true);
            // buttons.transform.rotation = image.transform.rotation;
        }
    }
    
    public override void OnDeselect(BaseEventData eventData)
    {
        buttons.SetActive(false);
    }
    
    public void rotateCounterClockwise()
    {
        image.transform.eulerAngles += new Vector3(0,0,rotationRate);
    }

    public void rotateClockwise()
    {
        image.transform.eulerAngles += new Vector3(0,0,-rotationRate);
    }
}
