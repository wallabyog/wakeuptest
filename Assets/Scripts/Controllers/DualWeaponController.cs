using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class DualWeaponController : BaseWeaponController
{
    [SerializeField] private int _damage = 10;
    [SerializeField] private float _bulletSpeed = 10f;
    
    [SerializeField] private Transform _leftBarrel;
    [SerializeField] private Transform _rightBarrel;

    [SerializeField] private BaseBullet _bullet;

    [SerializeField] private float _interval;

    private Transform[] _barrels = new Transform[2];
    
    private float _lastShootTime;
    private int _lastBarrelIndex = 0;
    
    private void Start()
    {
        _barrels[0] = _leftBarrel;
        _barrels[1] = _rightBarrel;
    }
    
    public override void Shoot()
    {
        if (CanShoot())
        {
            var barrel = GetCurrentBarrel();

            ObjectPool.Instance.Spawn<BaseBullet>(_bullet, null, barrel.position, barrel.rotation).Init(_damage, _bulletSpeed);
        }
    }

    private bool CanShoot()
    {
        if (Time.time >= _lastShootTime + _interval)
        {
            _lastShootTime = Time.time;
            return true;
        }
        
        return false;
    }

    private Transform GetCurrentBarrel()
    {
        var nextIndex = (_lastBarrelIndex + 1) % _barrels.Length;
        _lastBarrelIndex = nextIndex;
        
       return _barrels[nextIndex];
    }
}
