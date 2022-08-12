using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Boosts")]
public class BoostConfig : ScriptableObject
{
    [field: SerializeField] public float Amount { get; private set; }
    [field: SerializeField] public float WorkTime { get; private set; }
}


