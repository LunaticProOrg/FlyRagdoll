using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Movements/Camera")]
public class CameraFollowConfig : ScriptableObject
{
    [field: SerializeField] public float Height_Speed { get; private set; }
    [field: SerializeField] public float Damping { get; private set; }
}
