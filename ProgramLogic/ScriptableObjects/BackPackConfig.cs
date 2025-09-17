using UnityEngine;

[CreateAssetMenu(fileName = "BackPackConfig", menuName = "ScriptableObjects/BackPackConfig", order = 1)]
public class BackPackConfig : ItemConfig
{
    [Header("BackPack")]
    [SerializeField] public int Width;
    [SerializeField] public int Height;
}