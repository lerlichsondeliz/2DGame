using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager2 : MonoBehaviour
{
    public static Vector2 Movement2;

    private PlayerInput playerInput2;
    private InputAction moveAction2;
    
    private void Awake()
    {
        playerInput2 = GetComponent<PlayerInput>();

        moveAction2 = playerInput2.actions["Move"];
    }

    private void Update()
    {
        Movement2 = moveAction2.ReadValue<Vector2>();
    }
}
