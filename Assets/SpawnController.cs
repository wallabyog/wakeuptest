using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnController : BaseGameObject
{
    public event Action SpawnerCleared = delegate {  };
    public event Action SpawnerDestroyd = delegate {  };
    
    [SerializeField] private EntityData _prefab;
    
    List<IEntityData> _spawnedEntities = new List<IEntityData>();
    
    private void Start()
    {
        Vector3 spawnPoint = ThisTransform.position;

        _spawnedEntities.Add(Instantiate(_prefab, spawnPoint, ThisTransform.rotation));
        
        Broadcaster.Instance.AddListener(BroadcasterEvents.EntityKilled, OnEntityKilled);
    }

    private void OnEntityKilled(object[] obj)
    {
        var entity = (IEntityData)obj[0];

        _spawnedEntities.Remove(entity);

        if (_spawnedEntities.Count == 0)
        {
            SpawnerCleared.Invoke();
        }
    }

    private void OnDestroy()
    {
        SpawnerDestroyd.Invoke();
        Broadcaster.Instance.RemoveListener(BroadcasterEvents.EntityKilled, OnEntityKilled);
    }
    
}
