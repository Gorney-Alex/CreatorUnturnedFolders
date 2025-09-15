using UnityEngine;

[CreateAssetMenu(fileName = "VestConfig", menuName = "ScriptableObjects/VestConfig", order = 1)]
public class VestConfig : ItemConfig
{
    [Header("Vest")]
    [SerializeField] public float Armor;
    [SerializeField] public int Width;
    [SerializeField] public int Height;
}