using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static Vector2 Movement;

    public static bool Attack;

    private PlayerInput playerInput;
    private InputAction moveAction;

    private InputAction attackAction;
    
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();

        moveAction = playerInput.actions["Move"];

        attackAction = playerInput.actions["Attack"];
    }

    private void Update()
    {
        Movement = moveAction.ReadValue<Vector2>();
        Attack = attackAction.triggered;
    }
}
