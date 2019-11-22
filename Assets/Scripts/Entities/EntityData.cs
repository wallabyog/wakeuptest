using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityData : BaseGameObject, IEntityData
{
    [SerializeField] private bool _isBot;
    [SerializeField] private int _cost;

    public BaseGameObject Base => this;

    public DynamicData DynamicData { get; private set; }
    public bool IsBot => _isBot;
    public int Cost => _cost;

    private void Start()
    {
        InitDynamicData();
        LevelController.Instance.EntitiesCollection.Add(this);
    }

    private void InitDynamicData()
    {
        DynamicData = new DynamicData();
        
        DynamicData.MoveOutput = GetComponent<IMoveOutput>();
        DynamicData.AttackOutput = GetComponent<IAttackOutput>();
        DynamicData.TargetFinderOutput = GetComponent<ITargetFinderOutput>();
        DynamicData.HealthOutput = GetComponent<IHealthOutput>();
    }

    private void OnDestroy()
    {
        if (LevelController.Instance != null)
        {
            LevelController.Instance.EntitiesCollection.Remove(this);
        }
    }
}

public class DynamicData
{
    public IMoveOutput MoveOutput;
    public IAttackOutput AttackOutput;
    public ITargetFinderOutput TargetFinderOutput;
    public IHealthOutput HealthOutput;
}

public interface IEntityData
{
    BaseGameObject Base { get; }
    DynamicData DynamicData { get; }
    bool IsBot { get; }
    int Cost { get; }
}


