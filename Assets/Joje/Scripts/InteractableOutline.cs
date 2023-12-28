using System;
using System.Runtime.InteropServices;
using DG.Tweening;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// [RequireComponent(typeof(Collider))]
public class InteractableOutline : MonoBehaviour
{
    [SerializeField] public BoolReference[] activationConditions;
    public bool IsEnabled = true;
    [SerializeField] private float outlineTransitionTime;
    [SerializeField] private Ease outlineTransitionEase;
    [SerializeField] private float minOutline = 0.0f;
    [SerializeField] private float minOutline_WebGL = 0.0f;
    [SerializeField] private float maxOutline = 0.8f;
    
    private Renderer sprite;
    private bool canToggleOutlineOn = true; 
    private bool isMobile = false;
    private Tween onTween;
    private Tween offTween;
    


#if !UNITY_EDITOR && UNITY_WEBGL
        [DllImport("__Internal")]
        private static extern bool IsMobile();
#endif
    
    private void Start()
    {
        IsEnabled = true;
        sprite = GetComponent<Renderer>();
        HideVisualization();
        if (activationConditions is { Length: > 0 })
        {
            Toggle(Array.TrueForAll(activationConditions, c => c.Value == true));
        }
        
        // Array.ForEach(activationConditions, c =>
        // {
        //     c.AddListener(() =>
        //     {
        //         Toggle(c.Value);
        //     });
        // });

        canToggleOutlineOn = true;
        
        
#if !UNITY_EDITOR && UNITY_WEBGL
        isMobile = IsMobile();
#endif
    }
    
    private bool AreAllConditionsMet()
    {
        return activationConditions.Length <= 0 || Array.TrueForAll(activationConditions, c => c.Value);
    }

    public void OnMouseOver()
    {
        
        if (IsEnabled == false || AreAllConditionsMet() == false || EventSystem.current.IsPointerOverGameObject())
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

        if (canToggleOutlineOn == false)
        {
            return;
        }
        
        offTween.Kill();
        onTween = sprite.material.DOFloat(maxOutline, "_Thic", outlineTransitionTime).SetEase(outlineTransitionEase);
        canToggleOutlineOn = false;
    }

    private void HideVisualization()
    {
        onTween.Kill();
        offTween = sprite.material.DOFloat(isMobile ? minOutline_WebGL : minOutline, "_Thic", outlineTransitionTime).SetEase(outlineTransitionEase);
        canToggleOutlineOn = true;
    }

    public void Toggle(bool value)
    {
        IsEnabled = value;
        canToggleOutlineOn = value;

        if (value == true)
        {
            return;
        }
        onTween.Kill();
        offTween = sprite.material.DOFloat(0, "_Thic", outlineTransitionTime).SetEase(outlineTransitionEase);
    }
}