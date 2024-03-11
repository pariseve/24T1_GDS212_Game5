using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    public float speed = 5f;
    public float sprintSpeed = 10f; // Adjust the sprint speed as needed
    public float groundDistance = 0.1f;
    public float smoothingFactor = 10f; // Adjust this value for smoother movement
    public LayerMask groundLayer;
    public Rigidbody rb;
    public SpriteRenderer sr;
    public Animator animator;

    public bool isMoving = false;

    private bool isSprinting = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate; // Use interpolation for smoother movement
    }

    void Update()
    {
        RaycastHit hit;
        Vector3 castPos = transform.position + Vector3.up; // Slightly above the character
        if (Physics.Raycast(castPos, -Vector3.up, out hit, Mathf.Infinity, groundLayer))
        {
            float targetY = hit.point.y + groundDistance;
            Vector3 targetPosition = new Vector3(transform.position.x, targetY, transform.position.z);

            // Apply smoothing to character's position
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smoothingFactor);
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        // Check if the player is moving
        isMoving = (x != 0 || y != 0);

        // Set the IsMoving parameter in the animator
        animator.SetBool("IsMoving", isMoving);

        // Check if the player is sprinting
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }

        // Adjust speed based on sprinting state
        float currentSpeed = isSprinting ? sprintSpeed : speed;

        Vector3 moveDirection = new Vector3(x, 0, y) * currentSpeed;

        // Apply movement directly to the Rigidbody for smoother physics
        rb.velocity = moveDirection;

        // Handle character orientation (flipping sprite)
        if (x != 0)
        {
            sr.flipX = (x < 0);
        }
    }

}
