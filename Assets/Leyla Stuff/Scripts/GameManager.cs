using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public Transform spawnPoint;

    void Start()
    {
        Time.timeScale = 1f;
        // Retrieve the selected character index from PlayerPrefs
        int selectedCharacterIndex = PlayerPrefs.GetInt("SelectedCharacterIndex", 0);

        // Spawn the character using the retrieved index
        SpawnCharacter(selectedCharacterIndex);
    }

    public void SpawnCharacter(int characterIndex)
    {
        // Make sure the index is within bounds
        if (characterIndex >= 0 && characterIndex < characterPrefabs.Length)
        {
            // Instantiate the selected character prefab at the spawn point
            Instantiate(characterPrefabs[characterIndex], spawnPoint.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Invalid character index!");
        }
    }
}




