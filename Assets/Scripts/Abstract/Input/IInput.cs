using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInput
{
    InputData GetInput();
}

public class InputData
{
    public Vector3 Move;
    public bool IsMoving;
}
