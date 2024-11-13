using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f; // Jump force
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Horizontal and vertical movement inputs
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Move the player using Rigidbody
        Vector3 moveDirection = new Vector3(moveX, 0, moveZ).normalized;
        Vector3 velocity = moveDirection * moveSpeed;
        velocity.y = rb.velocity.y; // Preserve the y-velocity (gravity effect)

        rb.velocity = velocity;

        // Handle Jump (using space key)
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
