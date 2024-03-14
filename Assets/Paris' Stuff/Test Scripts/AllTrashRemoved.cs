using UnityEngine;
using cherrydev;

public class AllTrashRemoved : MonoBehaviour
{
    private GameObject[] litterObjects;

    public GameObject dialogueDisplay;
    public DialogNodeGraph dialogGraph;
    public SimpleDialogBehaviour dialogBehaviour;

    void Start()
    {
        // Find all game objects with the "Litter" tag in the scene
        litterObjects = GameObject.FindGameObjectsWithTag("Litter");
    }

    void Update()
    {
        // No need to check continuously; we'll check when a litter object is removed
    }

    public void OnLitterRemoved(GameObject removedObject)
    {
        // Update the litter objects array after a litter object is removed
        UpdateLitterObjectsArray(removedObject);

        // Check if all litter objects have been removed
        if (AreAllTrashRemoved())
        {
            Debug.Log("All litter objects have been removed!");

            TriggerDialogue();
        }
    }

    void UpdateLitterObjectsArray(GameObject removedObject)
    {
        // Remove the removed object from the litter objects array
        if (litterObjects != null && litterObjects.Length > 0)
        {
            int index = System.Array.IndexOf(litterObjects, removedObject);
            if (index != -1)
            {
                litterObjects[index] = null;
            }
        }
    }

    bool AreAllTrashRemoved()
    {
        // Check if there are no litter objects in the scene
        if (litterObjects == null || litterObjects.Length == 0)
        {
            return true;
        }

        // Iterate through all litter objects to check if any are still active
        foreach (GameObject obj in litterObjects)
        {
            if (obj != null && obj.activeSelf)
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
        // Activate the dialogue display game object
        dialogueDisplay.SetActive(true);

        // Start the dialog
        dialogBehaviour.StartDialog(dialogGraph);
    }
}
