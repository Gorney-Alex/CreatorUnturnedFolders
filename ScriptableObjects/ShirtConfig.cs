using UnityEngine;

[CreateAssetMenu(fileName = "ShirtConfig", menuName = "ScriptableObjects/ShirtConfig", order = 1)]
public class ShirtConfig : ItemConfig
{
    [Header("Shirt")]
    [SerializeField] public float Armor;
    [SerializeField] public int Width;
    [SerializeField] public int Height;
}