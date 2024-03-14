using UnityEngine;
using UnityEngine.EventSystems;

public class BinClickAnimation : MonoBehaviour, IPointerClickHandler
{
    public Animator animator;
    public string[] animationNames; // Names of the animations to play

    private bool isAnimating = true; // Start with animation playing
    private float lastClickTime; // Track the time of the last click

    void Start()
    {
        // Ensure the animator is not null
        if (animator == null)
        {
            Debug.LogError("Animator is not assigned.");
            enabled = false; // Disable the script if animator is not assigned
        }
    }

    void Update()
    {
        // Check if the animator is currently playing an animation
        if (!isAnimating)
        {
            // Check if enough time has passed since the last click
            if (Time.time - lastClickTime >= 3f)
            {
                // Allow clicking again
                isAnimating = true;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Prevent clicking if an animation is currently playing or not enough time has passed since the last click
        if (isAnimating)
        {
            // Randomly select an animation
            string animationName = animationNames[Random.Range(0, animationNames.Length)];

            // Play the selected animation
            animator.Play(animationName);

            // Update flag and last click time
            isAnimating = false;
            lastClickTime = Time.time;
        }
    }

    // Method to be called from animation event when animation finishes
    public void AnimationFinished()
    {
        // Play the "Bin" animation
        animator.Play("Bin");

        // Reset flag
        isAnimating = true;
    }
}




