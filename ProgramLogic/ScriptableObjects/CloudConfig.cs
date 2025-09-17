using UnityEngine;

[CreateAssetMenu(fileName = "CloudConfig", menuName = "ScriptableObjects/CloudConfig", order = 1)]
public class CloudConfig : ItemConfig
{
    [Header("Cloud")]
    [SerializeField] public float Gravity;
}