using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float maxSpeed;
    public float jumpForce;
    public float gravityScale = 2.5f; // Adjust this value for the strength of gravity

    private Rigidbody2D rb;
    public float rotationSpeed;
    private bool isJumping;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;
    }

    void Update()
    {
        if (speed < maxSpeed)
            speed += 0.1f * Time.deltaTime;

        rb.velocity = new Vector2(speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) && !isJumping)
        {
            if (Mathf.Abs(rb.velocity.x) > 0.1f)
            {
                RotateObjectAroundAxis();
            }

            Jump();
        }
    }

    private void RotateObjectAroundAxis()
    {
        transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isJumping = true;
    }
}
