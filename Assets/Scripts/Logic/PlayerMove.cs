using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : BaseEntity, IMove
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _rotationSpeed = 10f;

    private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }
    public void Move(InputData input)
    {
        var moveDirection = LevelController.Instance.MainCamera.transform.TransformDirection(input.Move);
        moveDirection.y = 0;
        
        _characterController.Move(moveDirection * _speed * Time.deltaTime);

        if (input.IsMoving)
            ThisTransform.rotation = Quaternion.LookRotation(moveDirection);
        else
        {
            var target = ThisEntity.DynamicData.TargetFinderOutput.Target;
            
            if (target != null)
            {
                var direction = (target.Base.ThisTransform.position - ThisTransform.position).normalized;

                direction = Vector3.ProjectOnPlane(direction, Vector3.up);
                
                ThisTransform.rotation = Quaternion.LookRotation(direction);
            }
        }
    }
}
