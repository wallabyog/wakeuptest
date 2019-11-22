using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttack : IAttackOutput
{
    void Attack(InputData input);
}

