using System;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// [RequireComponent(typeof(Collider))]
public class InteractableOutline : MonoBehaviour
{
    [SerializeField] public BoolReference[] activationConditions;
    public bool IsEnabled = true;
    private Renderer sprite;

    private void Start()
    {
        IsEnabled = true;
        sprite = GetComponent<Renderer>();
        HideVisualization();
        if (activationConditions is { Length: > 0 })
        {
            Toggle(Array.TrueForAll(activationConditions, c => c.Value == true));
        }
    }
    
    private bool AreAllConditionsMet()
    {
        return activationConditions.Length <= 0 || Array.TrueForAll(activationConditions, c => c.Value);
    }

    public void OnMouseEnter()
    {
        if (IsEnabled == false || AreAllConditionsMet() == false)
        {
            return;
        }
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

    public void Toggle(bool value)
    {
        IsEnabled = value;
    }
}