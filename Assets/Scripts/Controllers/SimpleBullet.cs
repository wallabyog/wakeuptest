using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : BaseBullet
{
    [SerializeField] private DecalController _decal;
    
    private void Update()
    {
        ThisTransform.Translate(ThisTransform.forward * _speed * Time.deltaTime, Space.World);
    }

    protected override void ApplyDamage(IHealth health)
    {
        health.ApplyDamage(_damage);
    }

    protected override void PreDestroy()
    { 
        ObjectPool.Instance.Spawn(_decal, null, ThisTransform.position - ThisTransform.forward * 0.5f, Quaternion.LookRotation(-ThisTransform.forward));
    }
}
