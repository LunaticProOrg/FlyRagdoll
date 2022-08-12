using System;
using UnityEngine;

internal class Boost : MonoBehaviour
{
    [SerializeField] private BoostConfig config;

    internal float GetAmount()
    {
        return config.Amount;
    }

    internal float GetWorkTime()
    {
        return config.WorkTime;
    }
}