using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]
public class InteractableOutline : MonoBehaviour
{
    private Renderer sprite;

    private void Start()
    {
        sprite = GetComponent<Renderer>();
        HideVisualization();
    }

    public void OnMouseEnter()
    {
        ShowVisualization();
        // print("Hover");
    }

    public void OnMouseExit()
    {
        HideVisualization();
        // print("HoverOut");
    }

    private void ShowVisualization()
    {
        sprite.material.SetFloat("_Thic", 0.8f);
    }

    private void HideVisualization()
    {
        sprite.material.SetFloat("_Thic", 0.0f);
    }
}