﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broadcaster
{
    private static Broadcaster _instance;

    public static Broadcaster Instance => Broadcaster._instance == null
        ? Broadcaster._instance = new Broadcaster()
        : Broadcaster._instance;
    
    private Dictionary<BroadcasterEvents, List<Action<object[]>>> _events = new Dictionary<BroadcasterEvents, List<Action<object[]>>>();

   public void AddListener(BroadcasterEvents code, Action<object[]> action)
   {
       if(!_events.ContainsKey(code))
           _events.Add(code, new List<Action<object[]>>());

       _events[code].Add(action);
   }

   public void RemoveListener(BroadcasterEvents code, Action<object[]> action)
   {
       if (!_events.ContainsKey(code))
           return;

       _events[code].Remove(action);
   }

   public void Invoke(BroadcasterEvents code, params object[] objs)
   {
       if (!_events.ContainsKey(code))
           return;

       foreach (var e in _events[code])
       {
           e?.Invoke(objs);
       }
   }
}

public enum BroadcasterEvents
{
    TargetFounded = 1,
    EntityKilled = 2,
    LevelCleared = 3,
}
