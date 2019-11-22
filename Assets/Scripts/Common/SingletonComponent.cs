using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingletonComponent<T>: BaseGameObject where T : Component
{
    public static T Instance { get; private set; }

    protected abstract T _instance { get; }

    protected virtual void Awake()
    {
        if (SingletonComponent<T>.Instance != null)
        {
            Destroy(this);
            return;
        }

        SingletonComponent<T>.Instance = _instance;
    }

    protected virtual void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }
}
