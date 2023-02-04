using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        imageColor.a = 1f;
        image.color = imageColor;
        print("Hover");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        imageColor.a = 0f;
        image.color = imageColor;
        print("HoverOut");
    }
}
