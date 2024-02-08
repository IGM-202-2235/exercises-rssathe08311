using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputController : MonoBehaviour
{
    public Vector3 inputDirection = Vector3.zero;

    [SerializeField] MovementController movementController;

    public void OnMove(InputAction.CallbackContext context)
    {
        inputDirection = context.ReadValue<Vector2>();


        movementController.Direction = inputDirection;
    }
}
