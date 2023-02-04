using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsableItem : ScriptableObject
{
    //TODO Conectar com os ELEMENTOS OPERÁVEIS
    [SerializeField] private string name;
    [SerializeField] private Sprite icon;
    [SerializeField] private int quantity;
    // [SerializeField] private OperableElement operableElement;

}
