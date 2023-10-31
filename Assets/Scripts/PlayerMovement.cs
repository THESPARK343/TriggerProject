using UnityEngine;

public class SimpleCharacterController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 5.0f;
    private Rigidbody rb;

    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check if the character is grounded.
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);

        // Move the character.
        //float horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetAxis("Horizontal") > 0)
        {
            rb.transform.Rotate(0.0f, 0.1f, 0.0f);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rb.transform.Rotate(0.0f, -0.1f, 0.0f);
        }
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(0.0f, 0.0f, verticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Jumping
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
