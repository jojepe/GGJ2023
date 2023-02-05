using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "UsableItem", menuName = "ScriptableObjects/UsableItem", order = 1)]
public class UsableItem : ScriptableObject
{
    //TODO Conectar com os ELEMENTOS OPERÁVEIS
    [SerializeField] private string name;
    [SerializeField] private Sprite icon;
    [SerializeField] private int initialQuantity = 1;
    [SerializeField] private int currentQuantity;
    [SerializeField] private int interactionIndex;

    public int InteractionIndex => interactionIndex;
    public Sprite Icon => icon;
    public int CurrentQuantity => currentQuantity;

    public void OnEnable()
    {
        currentQuantity = initialQuantity;
    }

    public void ReduceQuantity()
    {
        currentQuantity--;
    }

}
