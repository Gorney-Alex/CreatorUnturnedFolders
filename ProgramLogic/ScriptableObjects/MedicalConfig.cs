using UnityEngine;

//Gorney-Alex program

[CreateAssetMenu(fileName = "MedicalConfig", menuName = "ScriptableObjects/MedicalConfig", order = 1)]
public class MedicalConfig : ItemConfig
{
    [Header("Medical")]
    [SerializeField] public int Health;
    [SerializeField] public int Virus;
    [SerializeField] public int Energy;
    [SerializeField] public int Vision;
    [SerializeField] public bool IsAid;
    [SerializeField] public bool IsHealBleeding;
    [SerializeField] public bool IsHealBones;
}