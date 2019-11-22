using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : IScoreOutput, IDisposable
{
    private int _score = 0;
    
    public ScoreController()
    {
        Broadcaster.Instance.AddListener(BroadcasterEvents.EntityKilled, OnEntityKilled);
    }

    private void OnEntityKilled(object[] obj)
    {
        var entityData = (IEntityData)obj[0];

        if (entityData.IsBot)
        {
            _score += entityData.Cost;
        }
    }

    public void Dispose()
    {
        Broadcaster.Instance.RemoveListener(BroadcasterEvents.EntityKilled, OnEntityKilled);
    }

    public int Score => _score;
}

public interface IScoreOutput
{
    int Score { get; }
}
