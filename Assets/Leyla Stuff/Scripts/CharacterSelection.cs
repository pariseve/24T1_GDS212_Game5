using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public Image[] characterImages;
    public TMP_Text characterNameText;
    private int selectedCharacterIndex = 0;

    void Start()
    {
        UpdateCharacterSelection();
    }

    public void SelectNextCharacter()
    {
        selectedCharacterIndex = (selectedCharacterIndex + 1) % characterPrefabs.Length;
        UpdateCharacterSelection();
    }

    public void SelectPreviousCharacter()
    {
        selectedCharacterIndex = (selectedCharacterIndex - 1 + characterPrefabs.Length) % characterPrefabs.Length;
        UpdateCharacterSelection();
    }

    public void SelectCharacter()
    {
        PlayerPrefs.SetInt("SelectedCharacterIndex", selectedCharacterIndex);
    }

    void UpdateCharacterSelection()
    {
        for (int i = 0; i < characterPrefabs.Length; i++)
        {
            bool isSelected = i == selectedCharacterIndex;
            characterImages[i].gameObject.SetActive(isSelected);

            
            if (isSelected)
            {
                Sprite sprite = characterPrefabs[i].GetComponent<Sprite>(); 
                characterImages[i].sprite = sprite;
            }
        }

        characterNameText.text = characterPrefabs[selectedCharacterIndex].name;
    }
}





