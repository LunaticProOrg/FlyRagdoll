using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Movements/MainCharacter")]
public class MovementConfig : ScriptableObject
{
    [field: SerializeField] public float ForwardForce { get; private set; }
    [field: SerializeField] public ForceMode ForwardForceMode { get; private set; }
    [field: SerializeField] public float JumpForce { get; private set; }
    [field: SerializeField] public LayerMask JumpLayer { get; private set; }
    [field: SerializeField] public float HorizontalForce { get; private set; }
    [field: SerializeField] public float ClampHorizontalMin { get; private set; }
    [field: SerializeField] public float ClampHorizontalMax { get; private set; }


}

