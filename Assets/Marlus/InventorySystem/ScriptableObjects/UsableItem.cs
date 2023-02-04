using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UsableItem", menuName = "ScriptableObjects/UsableItem", order = 1)]
public class UsableItem : ScriptableObject
{
    //TODO Conectar com os ELEMENTOS OPERÁVEIS
    [SerializeField] private string name;
    [SerializeField] private Sprite icon;
    [SerializeField] private int quantity;
    [SerializeField] private int interactionIndex;

    public int InteractionIndex => interactionIndex;
    public Sprite Icon => icon;

}
