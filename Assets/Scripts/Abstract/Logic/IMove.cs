using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMove : IMoveOutput
{
    void Move(InputData input);
}