using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public GameObject optionsPanel;

    private void Start()
    {
        CloseOptions(); // Ensure the options panel is initially closed
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
        // Toggle the visibility of the options panel
        optionsPanel.SetActive(!optionsPanel.activeSelf);
    }

    public void CloseOptions()
    {
        // Close the options panel
        optionsPanel.SetActive(false);
    }
}


