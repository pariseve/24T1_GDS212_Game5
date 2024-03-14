using UnityEngine;

public class QuitButton : MonoBehaviour
{
    // Method to quit the game
    public void QuitGame()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Quit play mode in editor
#else
        Application.Quit(); // Quit application in builds
#endif
    }
}

