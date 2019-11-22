using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] private List<SpawnController> _spawners;

    private int _unclearedSpawnersCount;
    
    private void Start()
    {
        foreach (var s in _spawners)
        {
            s.SpawnerCleared += OnSpawnerCleared;
            s.SpawnerDestroyd += OnSpawnerCleared;
        }
        
        _unclearedSpawnersCount = _spawners.Count;
    }



    private void OnSpawnerCleared()
    {
        _unclearedSpawnersCount -= 1;

        if (_unclearedSpawnersCount == 0)
        {
            Broadcaster.Instance.Invoke(BroadcasterEvents.LevelCleared);
        }  
    }
}
