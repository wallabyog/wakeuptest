using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIInputController : MonoBehaviour, IInput
{
    private IAILogicOutput _aiLogicOutput;
    private InputData _inputData;

    void Start()
    {
        _inputData = new InputData();
        _aiLogicOutput = GetComponent<IAILogicOutput>();
    }


    void Update()
    {
        _inputData.Move = _aiLogicOutput.TargetPoint;
        _inputData.IsMoving = !_aiLogicOutput.SeesTarget;
    }
    
    public InputData GetInput()
    {
        return _inputData;
    }
}
