using UnityEngine;
using cherrydev;

public class TriggerDialogue : MonoBehaviour
{
    public GameObject dialogueDisplay;
    public DialogNodeGraph dialogGraph; // Reference to your dialog graph
    public SimpleDialogBehaviour dialogBehaviour; // Reference to your dialog behaviour script

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Activate the dialogue display game object
            dialogueDisplay.SetActive(true);

            // Start the dialog
            dialogBehaviour.StartDialog(dialogGraph);

            Debug.Log("Dialogue triggered!");
        }
    }
}
