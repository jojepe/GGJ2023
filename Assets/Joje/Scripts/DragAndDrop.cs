using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, ISelectHandler
{
    [SerializeField] UnityEvent OnUIElementReleased;
    private RectTransform draggingObject;

    private void Awake()
    {
        draggingObject = transform as RectTransform;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(draggingObject, eventData.position,
                eventData.pressEventCamera, out var globalMousePosition))
        {
            draggingObject.position = globalMousePosition;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnUIElementReleased.Invoke();
    }

    public void OnSelect(BaseEventData eventData)
    {
    }
}
