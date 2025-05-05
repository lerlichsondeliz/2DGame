using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    [SerializeField] private float moveSpeed2 = 5f;

    private Vector2 movement2;

    private Rigidbody2D rb2;
    private Animator animator2;
    private const string horizontal2 = "Horizontal2";
    private const string vertical2 = "Vertical2";
    private const string lastHorizontal2 = "lastHorizontal2";
    private const string lastVertical2 = "lastVertical2";

    private void Awake()
    {
        //attach components to game object
        rb2 = GetComponent<Rigidbody2D>();
        animator2 = GetComponent<Animator>();
    }
    
    private void Update()
    {
        movement2.Set(InputManager2.Movement2.x, InputManager2.Movement2.y);

        rb2.linearVelocity = movement2 * moveSpeed2;

        animator2.SetFloat(horizontal2, movement2.x);
        animator2.SetFloat(vertical2, movement2.y);

        if (movement2 != Vector2.zero) //as long as player is moving keep setting last values
        {
            animator2.SetFloat(lastHorizontal2, movement2.x);
            animator2.SetFloat(lastVertical2, movement2.y);
        }

    }
}
