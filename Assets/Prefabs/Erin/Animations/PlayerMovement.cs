using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator animator;
    private const string horizontal = "Horizontal"; //current x value
    private const string vertical = "Vertical"; //current y value
    private const string lastHorizontal = "lastHorizontal"; //last x value
    private const string lastVertical = "lastVertical"; //last y value
    void Awake()
    {
        //attach components to game object
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        movement.Set(InputManager.Movement.x, InputManager.Movement.y);
        rb.linearVelocity = movement.normalized * moveSpeed;

        //sets animator based on the movement vector
        animator.SetFloat(horizontal, movement.x);
        animator.SetFloat(vertical, movement.y);

        if (movement != Vector2.zero) //as long as the player is moving, keep setting the last values
        {
            animator.SetFloat(lastHorizontal, movement.x);
            animator.SetFloat(lastVertical, movement.y);
        }
    }
}
