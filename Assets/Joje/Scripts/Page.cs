using UnityEngine;
using UnityEngine.EventSystems;

public class Page : MonoBehaviour, IDragHandler, ISelectHandler, IDeselectHandler, IPointerDownHandler
{
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
        buttons.SetActive(true);
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
    
}
