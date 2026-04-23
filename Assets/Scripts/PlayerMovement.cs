using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 10f;
    public float laneDistance = 3f;
    public float laneChangeSpeed = 10f;
    public float jumpForce = 7f;
    private int currentLane = 1; // 0 = left, 1 = center, 2 = right
    private Rigidbody rigidBody;
    private bool isGrounded = true;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        HandleInput();
        HandleJump();
    }

    void FixedUpdate()
    {
        MoveForward();
        MoveToLane();
        
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        rigidBody.linearVelocity = new Vector3(rigidBody.linearVelocity.x, jumpForce, rigidBody.linearVelocity.z);
        isGrounded = false;
    }

    void MoveLeft()
    {
        if (currentLane > 0)
        {
            currentLane--;
        }
    }

    void MoveRight()
    {
        if (currentLane < 2)
        {
            currentLane++;
        }
    }

    void MoveForward()
    {
        Vector3 moveForward = Vector3.forward * forwardSpeed * Time.fixedDeltaTime;
        rigidBody.MovePosition(rigidBody.position + moveForward);
    }

    void MoveToLane()
    {
        float targetX = 0;

        if (currentLane == 0)
            targetX = -laneDistance;
        else if (currentLane == 2)
            targetX = laneDistance;

        Vector3 targetPosition = new Vector3(targetX, rigidBody.position.y, rigidBody.position.z);

        Vector3 newPosition = Vector3.Lerp(rigidBody.position, targetPosition, laneChangeSpeed * Time.fixedDeltaTime);

        rigidBody.MovePosition(newPosition);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
