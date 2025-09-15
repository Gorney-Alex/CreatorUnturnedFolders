using UnityEngine;

public class ItemConfig : ScriptableObject
{
    [Header("Rarity")]
    [SerializeField] public RarityType Rarity;
    
    [Header("X, Y, Z Camera")]
    [SerializeField] public int X;
    [SerializeField] public int Y;
    [SerializeField] public float Z;
    
    [Header("ModeName")]
    [SerializeField] public string ModeName;
    [SerializeField] public string ModeDescription;
    
    [Header("Optional part")]
    [SerializeField] public bool IsForMasterBundle;
}

public enum RarityType
{
    Common,
    Uncommon,
    Rare,
    Epic
}