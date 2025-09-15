using UnityEngine;

[CreateAssetMenu(fileName = "BarricadeConfig", menuName = "ScriptableObjects/BarricadeConfig", order = 1)]
public class BarricadeConfig : ItemConfig
{
    [Header("Barricade")]
    [SerializeField] public int Health;
    [SerializeField] public float Range;
    [SerializeField] public float Radius;
    [SerializeField] public float Offset;
    [SerializeField] public int Explosion;
}