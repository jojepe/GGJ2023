using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D))]
public class InteractableOutline : MonoBehaviour
{
    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        HideVisualization();
    }

    public void OnMouseEnter()
    {
        ShowVisualization();
        print("Hover");
    }

    public void OnMouseExit()
    {
        HideVisualization();
        print("HoverOut");
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