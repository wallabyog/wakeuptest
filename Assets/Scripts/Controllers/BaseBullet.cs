using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBullet : BaseGameObject
{
    [SerializeField] float _lifeTime = 5f;
    
    protected int _damage = 0;
    protected float _speed = 0;

    public void Init(int damage, float speed)
    {
        _damage = damage;
        _speed = speed;
    }

    private void OnEnable()
    {
        StartCoroutine(LifeTimer());  
    }
    
    IEnumerator LifeTimer()
    {
        yield return new WaitForSeconds(_lifeTime);
        
        ObjectPool.Instance.Recycle(ThisGameObject);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        var damageable = other.GetComponent<IHealth>();

        if (damageable != null)
        {
            ApplyDamage(damageable);
        }
        
        PreDestroy();
        
        ObjectPool.Instance.Recycle(ThisGameObject);
    }

    protected abstract void ApplyDamage(IHealth health);
    protected abstract void PreDestroy();
}