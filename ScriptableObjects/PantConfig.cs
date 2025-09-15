using UnityEngine;

[CreateAssetMenu(fileName = "PantConfig", menuName = "ScriptableObjects/PantConfig", order = 1)]
public class PantConfig : ItemConfig
{
    [Header("Pants")]
    [SerializeField] public float Armor;
    [SerializeField] public int Width;
    [SerializeField] public int Height;
}