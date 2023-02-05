using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Interactable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image image;

    private Color imageColor;
    
    private void Start()
    {
        Color imageColor = image.color;
        HideVisualization();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ShowVisualization();
        print("Hover");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        HideVisualization();
        print("HoverOut");
    }

    private void ShowVisualization()
    {
        imageColor.a = 1f;
        image.color = imageColor;
    }

    private void HideVisualization()
    {
        imageColor.a = 0f;
        image.color = imageColor;
    }
}
