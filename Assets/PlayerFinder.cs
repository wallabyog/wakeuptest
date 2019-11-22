using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFinder : BaseEntity, ITargetFinder
{
    private IEntityData _target;
    
    public IEntityData Target => _target;

    private void Start()
    {
        Broadcaster.Instance.AddListener(BroadcasterEvents.EntityKilled, OnEntityKilled);
    }

    private void OnDestroy()
    {
        Broadcaster.Instance.RemoveListener(BroadcasterEvents.EntityKilled, OnEntityKilled);
    }

    private void OnEntityKilled(object[] obj)
    {
        IEntityData entity = (IEntityData)obj[0];
        
        if (entity == _target)
            _target = null;
    }
    
    public void FindTarget(InputData input)
    {
        _target = LevelController.Instance.EntitiesCollection.Player;
    }
}
