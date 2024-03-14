using UnityEngine;

public class GameOptionsMenu : MonoBehaviour
{
    public GameObject optionsPanel;

    private bool isMenuOpen = false;
    private float previousTimeScale; // To store the previous time scale value
    private PlayerMovement playerMovement; // Reference to the PlayerMovement script

    private void Start()
    {
        CloseOptions(); // Ensure the options panel is initially closed

        // Find the player GameObject and get a reference to its PlayerMovement script
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            playerMovement = playerObject.GetComponent<PlayerMovement>();
        }
        else
        {
            Debug.LogWarning("Player GameObject not found.");
        }
    }

    private void Update()
    {
        // Check for Escape key press to toggle options menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleOptions();
        }
    }

    public void ToggleOptions()
    {
        isMenuOpen = !isMenuOpen;

        if (isMenuOpen)
        {
            OpenOptions();
        }
        else
        {
            CloseOptions();
        }
    }

    private void OpenOptions()
    {
        // Freeze time
        previousTimeScale = Time.timeScale;
        Time.timeScale = 0f;

        // Freeze player movement
        if (playerMovement != null)
        {
            playerMovement.FreezeMovement();
        }

        // Open the options panel
        optionsPanel.SetActive(true);
    }

    public void CloseOptions()
    {
        // Unfreeze time
        Time.timeScale = previousTimeScale;

        // Unfreeze player movement
        if (playerMovement != null)
        {
            playerMovement.UnfreezeMovement();
        }

        // Close the options panel
        optionsPanel.SetActive(false);
    }
}
