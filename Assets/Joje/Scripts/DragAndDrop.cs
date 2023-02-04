using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, ISelectHandler
{
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
        throw new NotImplementedException();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }

    public void OnSelect(BaseEventData eventData)
    {
        throw new NotImplementedException();
    }
}
