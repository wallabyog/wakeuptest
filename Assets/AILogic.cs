using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AILogic : BaseEntity, IAILogicOutput
{
    [SerializeField] private LayerMask _walls;

    private IEntityData _target => ThisEntity.DynamicData.TargetFinderOutput.Target;
    
    private Vector3 _targetPoint;
    private bool _seesTarget;
    
    private void Update()
    {
        if (_target == null)
            return;
        
        RaycastHit hit;
        
        _targetPoint = _target.Base.ThisTransform.position;
        _seesTarget = !Physics.Linecast(_target.Base.ThisTransform.position, ThisTransform.position +  Vector3.up * 2f, out hit, _walls);
    }

    public bool SeesTarget => _seesTarget;

    public Vector3 TargetPoint => _targetPoint;
}

public interface IAILogicOutput
{
    bool SeesTarget { get; }
    Vector3 TargetPoint { get; }
}
