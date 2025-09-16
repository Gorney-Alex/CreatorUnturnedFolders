using UnityEngine;

[CreateAssetMenu(fileName = "EdibleConfig", menuName = "ScriptableObjects/EdibleConfig", order = 1)]
public class EdibleConfig : ItemConfig
{
    [Header("Edible")]
    [SerializeField] public int Health;
    [SerializeField] public int Food;
    [SerializeField] public int Water;
    [SerializeField] public int Virus;
    [SerializeField] public int Vision;
    [SerializeField] public int Energy;
}