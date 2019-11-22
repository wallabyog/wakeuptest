using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth : IHealthOutput
{
    void ApplyDamage(int value);
}

public interface IHealthOutput
{
    int CurrentHp { get; }
}
