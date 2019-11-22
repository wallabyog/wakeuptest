using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : BaseEntity, IHealth
{
    [SerializeField] private int _maxHp = 100;

    private int _currentHp;

    private void Start()
    {
        _currentHp = _maxHp;
    }
    public void ApplyDamage(int value)
    {
        _currentHp -= value;

        if (_currentHp <= 0)
        {
            Broadcaster.Instance.Invoke(BroadcasterEvents.EntityKilled, ThisEntity);
            Destroy(ThisGameObject);
        }

    }

    public int CurrentHp => _currentHp;
}
