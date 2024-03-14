using UnityEngine;
using UnityEngine.UI;

public class ButtonClickSound : MonoBehaviour
{
    public AudioSource clickSound;

    void Start()
    {
        // Find all buttons in the scene, including inactive ones
        Button[] buttons = Resources.FindObjectsOfTypeAll<Button>();

        // Iterate through each button and add a click listener
        foreach (Button button in buttons)
        {
            // Add a click listener to the button
            button.onClick.AddListener(() => PlayClickSound());
        }
    }

    // Method to play the click sound
    void PlayClickSound()
    {
        if (clickSound != null)
        {
            clickSound.Play();
        }
        else
        {
            Debug.LogWarning("Click sound is not assigned.");
        }
    }
}


