using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject instructionsPanel, aboutUsPanel;
    [SerializeField] private GameObject button;

    // Method to start the game
    public void PlayGame()
    {
        SceneManager.LoadScene("GameplayScene");
    }

    // Method to show instructions
    public void ShowInstructions()
    {
        instructionsPanel.SetActive(true);
        button.SetActive(false);
    }

    // Method to hide instructions
    public void HideInstructions()
    {
        instructionsPanel.SetActive(false);
        button.SetActive(true);
    }

    public void ShowAboutUs()
    {
        aboutUsPanel.SetActive(true);
        button.SetActive(false);
    }

    public void HideAboutUs()
    {
        aboutUsPanel.SetActive(false);
        button.SetActive(true);
    }

    // Quit Game
    public void QuitGame()
    {
        Application.Quit();
    }
}
