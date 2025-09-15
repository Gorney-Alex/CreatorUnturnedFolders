using UnityEngine;

public class ItemConfig : ScriptableObject
{
    [Header("X, Y, Z Camera")]
    [SerializeField] public int X;
    [SerializeField] public int Y;
    [SerializeField] public float Z;
    
    [Header("ModeName")]
    [SerializeField] public string ModeName;
    [SerializeField] public string ModeDescription;
    
    public const string ENGLISH_FILE_NAME = "English.dat";
}