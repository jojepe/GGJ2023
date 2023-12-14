using System;
using Marlus.InventorySystem.ScriptableObjects;
using UnityEngine;

[CreateAssetMenu(fileName = "UsableItem", menuName = "ScriptableObjects/UsableItem", order = 1)]
public class UsableItem : ScriptableObject
{
    //TODO Conectar com os ELEMENTOS OPERÁVEIS
    [SerializeField] private string name;
    [SerializeField] private Sprite icon;
    [SerializeField] private int initialQuantity = 1;
    [SerializeField] private int currentQuantity;
    [SerializeField] private int interactionIndex;
    public Inventory _inventory;
    public bool hasBeenCollected = false;
    public bool hasBeenSet = false;

    public int InteractionIndex => interactionIndex;
    public Sprite Icon => icon;
    public int CurrentQuantity => currentQuantity;

    public void OnEnable()
    {
        currentQuantity = initialQuantity;
        hasBeenCollected = false;
        hasBeenSet = false;
    }

    public void Awake()
    {
        hideFlags = HideFlags.DontUnloadUnusedAsset;
    }

    public void ReduceQuantity()
    {
        currentQuantity--;
    }
    

}
