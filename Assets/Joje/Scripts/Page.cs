using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Page : Selectable, IDragHandler
{
    public UsableItem usableItem;
    public new GameObject image;
    public GameObject buttons;
    [Header("ScreenLimit")] 
    public int maxX;
    public int minX;
    public int maxY;
    public int minY;
    [Header("GameEvents")]
    [SerializeField] private GameEvent onPageSelected;
    [SerializeField] private GameEvent onPageRotated;
    
    private RectTransform draggingObject;
    private Vector3 targetPosition;
    
    private const float rotationRate = 22.5f;

    protected override void Awake()
    {
        draggingObject = transform as RectTransform;
        image.SetActive(usableItem.hasBeenSet);
    }

    protected override void OnEnable()
    {
        if (usableItem.hasBeenSet == false)
        {
            return;
        }
        SetTransform();
    }

    private void SetTransform()
    {
        if (usableItem.positionOnBoard.HasValue)
        {
            draggingObject.position = usableItem.positionOnBoard.Value;
        }

        if (usableItem.rotationOnBoard.HasValue)
        {
            image.transform.rotation = usableItem.rotationOnBoard.Value;
            buttons.transform.rotation = usableItem.rotationOnBoard.Value;
        }
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
        draggingObject.position = targetPosition;
        usableItem.positionOnBoard = targetPosition;
        // print(draggingObject.position);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        // Debug.Log("Pointer down on: " + gameObject.name);
        if (eventData.button != PointerEventData.InputButton.Left)
            return;
        if (image.activeSelf == false || interactable == false)
        {
            return;
        }
        // Debug.Log(gameObject.name + " should be selected");
        EventSystem.current.SetSelectedGameObject(gameObject, eventData);
    }

    public override void OnSelect(BaseEventData eventData)
    {
        if (image.activeSelf == true)
        {
            // Debug.Log("Rotation button toggled on");
            buttons.SetActive(true);
            onPageSelected.Raise();
        }
    }
    
    public override void OnDeselect(BaseEventData eventData)
    {
        buttons.SetActive(false);
    }

    public void rotateCounterClockwise() => Rotate(false);

    public void rotateClockwise() => Rotate(true);

    public void Rotate(bool clockwise)
    {
        var signal = clockwise ? -1 : 1;
        image.transform.eulerAngles += new Vector3(0,0,signal * rotationRate);
        usableItem.rotationOnBoard = image.transform.rotation;
        onPageRotated.Raise();
    }
}
