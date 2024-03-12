using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCollection : MonoBehaviour
{
    public Transform itemHolder; // The empty GameObject attached to the player character to hold items
    public Transform depositLocation; // The location where items will be deposited

    private GameObject itemHeld; // The item currently held by the player
    private bool isNearDeposit; // Flag to track if the player is near the deposit location

    void Update()
    {
        // Check for input to pick up or drop items
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (itemHeld == null)
            {
                // If the player isn't holding an item, try to pick up an item
                TryPickupItem();
            }
            else if (isNearDeposit)
            {
                // If the player is holding an item and near the deposit zone, try to deposit it
                DepositItem();
            }
        }
    }

    void TryPickupItem()
    {
        // Check for nearby items within the player's reach
        Collider[] nearbyColliders = Physics.OverlapSphere(transform.position, 2f);
        foreach (Collider col in nearbyColliders)
        {
            if (col.CompareTag("Litter"))
            {
                // If an item is found, pick it up
                itemHeld = col.gameObject;
                itemHeld.transform.SetParent(itemHolder); // Attach the item to the item holder GameObject
                itemHeld.transform.localPosition = Vector3.zero; // Set the local position to zero to fix it to the holder
                itemHeld.GetComponent<Rigidbody>().isKinematic = true; // Make the item kinematic to prevent physics interactions
                itemHeld.GetComponent<Collider>().isTrigger = true; // Set the collider as a trigger to disable physics interactions
                break;
            }
        }
    }

    void DepositItem()
    {
        if (itemHeld != null)
        {
            // Deposit the held item at the deposit location
            itemHeld.transform.SetParent(null); // Release the item from the player
            itemHeld.transform.position = depositLocation.position; // Move the item to the deposit location
            itemHeld.GetComponent<Rigidbody>().isKinematic = false; // Make the item non-kinematic to enable physics interactions
            itemHeld.GetComponent<Collider>().isTrigger = false; // Set the collider as not a trigger to enable physics interactions
            Destroy(itemHeld); // Destroy the deposited item
            itemHeld = null; // Reset the held item
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DepositZone"))
        {
            isNearDeposit = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("DepositZone"))
        {
            isNearDeposit = false;
        }
    }
}