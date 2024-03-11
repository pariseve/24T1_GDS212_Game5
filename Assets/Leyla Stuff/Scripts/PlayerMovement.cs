using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    private Animator animator;
    private Vector3 lastMovementDirection = Vector3.right; // Default direction

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Update animation based on movement
        if (movementDirection != Vector3.zero) // If moving
        {
            if (movementDirection.x != 0) // Moving left or right
            {
                lastMovementDirection = movementDirection.x > 0 ? Vector3.right : Vector3.left;
                animator.Play(movementDirection.x > 0 ? "WalkRight" : "WalkLeft");
            }
            else // Moving forward or backward
            {
                animator.Play(lastMovementDirection.x > 0 ? "WalkRight" : "WalkLeft");
            }
        }
        else // If not moving
        {
            animator.Play(lastMovementDirection.x > 0 ? "IdleRight" : "IdleLeft");
        }

        // Move the player
        transform.Translate(movementDirection * moveSpeed * Time.deltaTime);
    }
}



