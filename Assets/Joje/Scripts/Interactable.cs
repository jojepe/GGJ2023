using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Interactable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image lupa;

    private Color lupaColor;
    
    private void Start()
    {
        Color lupaColor = lupa.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        lupaColor.a = 1f;
        lupa.color = lupaColor;
        print("Hover");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        lupaColor.a = 0f;
        lupa.color = lupaColor;
        print("HoverOut");
    }
}
