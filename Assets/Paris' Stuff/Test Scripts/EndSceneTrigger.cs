using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneTrigger : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public void GoToScene()
    {
        // Check if the scene name is valid
        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.LogWarning("Scene name is not specified.");
            return;
        }

        // Load the specified scene
        SceneManager.LoadScene(sceneName);
        Debug.Log("Transitioning to scene: " + sceneName);
    }

}
