using UnityEngine;
using cherrydev;

public class AllTrashRemoved : MonoBehaviour
{
    public bool isTrashGone = false;

    public GameObject dialogueDisplay;
    public DialogNodeGraph dialogGraph;
    public SimpleDialogBehaviour dialogBehaviour;

    private void Start()
    {
        isTrashGone = false;
    }

    void Update()
    {
        if (!isTrashGone)
        {
            // Find all game objects with the "Litter" tag in the scene
            GameObject[] litterObjects = GameObject.FindGameObjectsWithTag("Litter");

            // Check if all litter objects have been removed
            if (AreAllTrashRemoved(litterObjects))
            {
                Debug.Log("All litter objects have been removed!");

                TriggerDialogue();
            }
        }
        
    }

    bool AreAllTrashRemoved(GameObject[] litterObjects)
    {
        // Iterate through all litter objects to check if any are still active
        foreach (GameObject obj in litterObjects)
        {
            if (obj.activeSelf)
            {
                // If any litter object is still active, return false
                return false;
            }
        }
        // If no litter objects are active, return true
        return true;
    }

    void TriggerDialogue()
    {
        isTrashGone = true;
        // Activate the dialogue display game object
        dialogueDisplay.SetActive(true);

        // Start the dialog
        dialogBehaviour.StartDialog(dialogGraph);
    }
}
