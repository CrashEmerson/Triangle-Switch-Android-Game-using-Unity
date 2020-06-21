using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    AudioManager audioManager;
    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    public void LoadStageLevel()
    {
        MenuUISFX();
        SceneManager.LoadScene("SelectStage");
    }
    public void Quit()
    {
        MenuUISFX();
        Application.Quit();
    }
    public void LoadMainMenu()
    {
        MenuUISFX();
        SceneManager.LoadScene(0); // 0 -> Mainmenu
    }
    public void LoadCredits()
    {
        MenuUISFX();
        SceneManager.LoadScene("Credits");
    }
    
    public void Restart()
    {
        MenuUISFX();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (Time.timeScale == 0) { Time.timeScale = 1f; }
    }
    public void NextLevel(string levelname)
    {
        MenuUISFX();
        SceneManager.LoadScene(levelname);
    }
    public void LoadOptions()
    {
        MenuUISFX();
        SceneManager.LoadScene("Options");
    }
    public void selectLevel()
    {
        SceneManager.LoadScene("SelectLevel");
    }
    
    private void MenuUISFX() { audioManager.Play("MenuSelectUI"); }
}