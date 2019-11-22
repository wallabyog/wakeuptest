using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotMove : BaseEntity, IMove
{
    private NavMeshAgent _navMeshAgent;
    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
    
    public void Move(InputData input)
    {
        _navMeshAgent.isStopped = !input.IsMoving;

        _navMeshAgent.SetDestination(input.Move);
        
        var direction = (input.Move - ThisTransform.position).normalized;

        direction = Vector3.ProjectOnPlane(direction, Vector3.up);
        
        ThisTransform.rotation = Quaternion.LookRotation(direction);
    }
}
