using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourController : MonoBehaviour
{
    private IInput _currentInput;
    
    private IMove _move;
    private IAttack _attack;
    private ITargetFinder _find;

    private void Start()
    {
        _currentInput = GetComponent<IInput>();
        
        _move = GetComponent<IMove>();
        _attack = GetComponent<IAttack>();
        _find = GetComponent<ITargetFinder>();
    }

    private void Update()
    {
        var input = _currentInput.GetInput();
        
        _move?.Move(input);
        _attack?.Attack(input);
        _find?.FindTarget(input);
    }
}
