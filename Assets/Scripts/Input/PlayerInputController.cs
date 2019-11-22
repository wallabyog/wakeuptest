using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour, IInput
{
    private IInput _currentInput;
    
    private void Start()
    {
        _currentInput = new DesktopInputController();
    }

    public InputData GetInput()
    {
        return _currentInput.GetInput();
    }
}

public class DesktopInputController : IInput
{
    private readonly InputData _inputData = new InputData();
    
    public InputData GetInput()
    {
        _inputData.Move = Vector3.ClampMagnitude(new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical")),1 );
        _inputData.IsMoving = _inputData.Move.sqrMagnitude > Mathf.Epsilon;
        
        return _inputData;
    }
}
