using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotFinder: BaseEntity, ITargetFinder
{
    private IEntityData _target;

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
        IEntityData nearestTarget = default(IEntityData);
        float minDistance = float.MaxValue;
        
        foreach (var e in LevelController.Instance.EntitiesCollection.OtherEntities)
        {
            if (e.Base.ThisGameObject == ThisGameObject)
                continue;

            var distance = (e.Base.ThisTransform.position - ThisTransform.position).sqrMagnitude;

            if (distance < minDistance)
            {
                minDistance = distance;
                nearestTarget = e;
            }
        }

        if (_target != nearestTarget)
        {
            _target = nearestTarget;
            
            Broadcaster.Instance.Invoke(BroadcasterEvents.TargetFounded, _target);
        }
    }

    public IEntityData Target => _target;
}

public interface ITargetFinder : ITargetFinderOutput
{
    void FindTarget(InputData input);
}
