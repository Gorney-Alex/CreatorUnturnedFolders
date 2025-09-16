using UnityEngine;

[CreateAssetMenu(fileName = "HatConfig", menuName = "ScriptableObjects/HatConfig", order = 1)]
public class HatConfig : ItemConfig
{
    [Header("Hat")]
    [SerializeField] public float Armor;
}