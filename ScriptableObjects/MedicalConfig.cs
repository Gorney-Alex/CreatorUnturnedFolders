using UnityEngine;

[CreateAssetMenu(fileName = "MedicalConfig", menuName = "ScriptableObjects/MedicalConfig", order = 1)]
public class MedicalConfig : ItemConfig
{
    [Header("Medical")]
    [SerializeField] public int Health;
    [SerializeField] public bool isAid;
    [SerializeField] public bool isHealBleeding;
    [SerializeField] public bool isHealBones;
}