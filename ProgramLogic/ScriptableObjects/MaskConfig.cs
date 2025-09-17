using UnityEngine;

//Gorney-Alex program

[CreateAssetMenu(fileName = "MaskConfig", menuName = "ScriptableObjects/MaskConfig", order = 1)]
public class MaskConfig : ItemConfig
{
    [Header("Mask")]
    [SerializeField] public bool IsProofRadiation;
}