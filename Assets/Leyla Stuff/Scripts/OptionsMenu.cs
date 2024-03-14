// OptionsMenu.cs
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public GameObject optionsPanel;

    private void Start()
    {
        optionsPanel.SetActive(false);
    }

    public void ToggleOptions()
    {
        optionsPanel.SetActive(!optionsPanel.activeSelf);
    }

    public void CloseOptions()
    {
        optionsPanel.SetActive(false);
    }
}

