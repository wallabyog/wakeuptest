using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAttack : BaseEntity, IAttack
{
    [SerializeField] private BaseWeaponController _weapon;
    
    public void Attack(InputData input)
    {
        var hasTarget = ThisEntity.DynamicData.TargetFinderOutput.Target != null;
        
        if (!input.IsMoving && hasTarget)
        {
            _weapon.Shoot();
        }
    }
}
