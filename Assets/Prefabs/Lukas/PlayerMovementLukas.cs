using UnityEngine;

public class PlayerMovementLukas : MonoBehaviour
{
    public float speed = 20f;
    public bool isPlayerOne = true; // Set this in the Inspector for each player
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;

    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";
    private const string lastHorizontal = "lastHorizontal";
    private const string lastVertical = "lastVertical";

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isPlayerOne)
        {
            moveInput.x = Input.GetAxisRaw("Horizontal");
            moveInput.y = Input.GetAxisRaw("Vertical");
        }
        else
        {
            moveInput.x = Input.GetAxisRaw("HorizontalP2");
            moveInput.y = Input.GetAxisRaw("VerticalP2");
        }

        // Update animator with movement info
        animator.SetFloat(horizontal, moveInput.x);
        animator.SetFloat(vertical, moveInput.y);

        if (moveInput != Vector2.zero)
        {
            animator.SetFloat(lastHorizontal, moveInput.x);
            animator.SetFloat(lastVertical, moveInput.y);
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput.normalized * speed;
    }
}
