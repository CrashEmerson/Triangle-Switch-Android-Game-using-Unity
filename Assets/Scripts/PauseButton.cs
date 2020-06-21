using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject backgroundUI;
    AudioManager audioManager;
    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    public void Pause()
    {
        MenuUISFX();
        pauseMenu.SetActive(true);
        backgroundUI.SetActive(false);
        Time.timeScale = 0f;
    }
    
    public void Resume()
    {
        MenuUISFX();
        pauseMenu.SetActive(false);
        backgroundUI.SetActive(true);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        MenuUISFX();
        Time.timeScale = 1f;
        SceneManager.LoadScene(0); // load mainmenu
    }
    public void Quit()
    {
        MenuUISFX();
        Application.Quit();
    }

    private void MenuUISFX()  { if (audioManager != null) { audioManager.Play("MenuSelectUI"); } }
}