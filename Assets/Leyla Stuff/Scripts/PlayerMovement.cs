using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float initialMoveSpeed = 1f; // Initial move speed set in the inspector
    private float moveSpeed; // Current move speed
    private Animator[] childAnimators; // Array to hold all Animator components in children
    private Vector3 lastMovementDirection = Vector3.right; // Default direction

    void Start()
    {
        // Get all Animator components in children
        childAnimators = GetComponentsInChildren<Animator>();

        // Set the current move speed to the initial move speed
        moveSpeed = initialMoveSpeed;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Update animation based on movement for each child animator
        foreach (Animator animator in childAnimators)
        {
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
        }

        // Move the player
        transform.Translate(movementDirection * moveSpeed * Time.deltaTime);
    }

    public void FreezeMovement()
    {
        // Stop player movement
        moveSpeed = 0f;
    }

    public void UnfreezeMovement()
    {
        // Resume player movement
        moveSpeed = initialMoveSpeed;
    }
}






