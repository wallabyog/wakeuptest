using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitiesCollection
{
    private List<IEntityData> _otherEntities = new List<IEntityData>();

    public IEntityData Player { get; private set; }
    public IReadOnlyList<IEntityData> OtherEntities => _otherEntities;

    public void Add(IEntityData data)
    {
        if (!data.IsBot && Player == null)
        {
            Player = data;
            return;
        }

        if(data.IsBot && !_otherEntities.Contains(data))
            _otherEntities.Add(data);
    }

    public void Remove(IEntityData data)
    {
        if (!data.IsBot && Player == data)
        {
            Player = null;
            return;
        }
        
        _otherEntities.Remove(data);
    }
}
