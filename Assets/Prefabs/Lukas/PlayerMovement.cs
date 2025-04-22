using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 20f;
    public bool isPlayerOne = true; // Set this in the Inspector for each player
    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput.normalized * speed;
    }
}