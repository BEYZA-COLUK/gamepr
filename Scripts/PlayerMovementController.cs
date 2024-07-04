using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private AnimationController animationController;
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private DynamicJoystick dynamicJoystick;
    [SerializeField] private Transform playerChildTransform;
    [SerializeField] private float moveSpeed;

    private float _horizontal;
    private float _vertical;

    private void Update()
    {
        GetMovementInputs();
    }

    private void FixedUpdate()
    {
        SetMovement();
        SetRotation();
    }

    private void SetMovement()
    {
        Vector3 newVelocity = GetNewVelocity();

       
        if (_horizontal == 0 && _vertical == 0)
        {
            playerRigidbody.velocity = Vector3.zero;
        }
        else
        {
            playerRigidbody.velocity = newVelocity;
        }

        animationController.SetBoolean("Run", _horizontal != 0 || _vertical != 0);
    }

    private void SetRotation()
    {
        if (_horizontal != 0 || _vertical != 0)
        {
            playerChildTransform.rotation = Quaternion.LookRotation(GetNewVelocity());
        }
    }

    private Vector3 GetNewVelocity()
    {
        return new Vector3(_horizontal, 0, _vertical) * moveSpeed * Time.fixedDeltaTime;
    }

    private void GetMovementInputs()
    {
        _horizontal = dynamicJoystick.Horizontal;
        _vertical = dynamicJoystick.Vertical;
    }
}
