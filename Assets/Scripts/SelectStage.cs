using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class SelectStage : MonoBehaviour
{
    [SerializeField] int StarsToUnlockLevel;
    [SerializeField] GameObject LockUI;
    [SerializeField] GameObject LevelLockUI;
    [SerializeField] TextMeshProUGUI stageLockedMessage;
    [SerializeField] GameObject HowToPlayUI;
    
    int starsNeeded;
    int totalStarsGained = 0; 
    public void LoadLanternLevel()
    {
        MenuUISFX();
        SceneManager.LoadScene("Lantern_SelectLevel"); // Loads lantern select level;
    }
    public void LoadFireBallLevel()
    {
        MenuUISFX();
        if (LockUI.activeSelf == false)
            SceneManager.LoadScene("FireBall_SelectLevel"); // Loads FireBall select level;
        else stageLockedMessage.text = starsNeeded.ToString() + " stars needed"; LevelLockUI.SetActive(true);
    }
    public void LoadShrinkLevel()
    {
        MenuUISFX();
        if (LockUI.activeSelf == false)
            SceneManager.LoadScene("Shrink_SelectLevel"); // Loads Shrink select level;
        else stageLockedMessage.text = starsNeeded.ToString() + " stars needed"; LevelLockUI.SetActive(true);
    }
    public void LoadTImeLevel()
    {
        MenuUISFX();
        if (LockUI.activeSelf == false)
            SceneManager.LoadScene("Time_SelectLevel"); //Loads Time select level;
        else stageLockedMessage.text = starsNeeded.ToString() + " stars needed"; LevelLockUI.SetActive(true);
    }

    private void Start()
    {
        lockStage();
    }
    void lockStage()
    {
        string[] stagnames = { "Lantern", "FireBall", "Shrink", "Time" };
        List<string> levels = new List<string>();
        for (int i = 1; i <= 5; i++)
        {
            string levelname = "Level0" + i;
            levels.Add(levelname);
        }
        
        for (int i = 0; i < stagnames.Length; i++)
        {
            foreach (string element in levels)
            {
                int value = PlayerData.LoadStarData(element,stagnames[i]);    // LoadStarData( level01, Lantern )
                totalStarsGained = totalStarsGained + value;
            }
        }
    }
    private void Update()
    {
        if (totalStarsGained < StarsToUnlockLevel) //  15 < 15
        {
            if (LockUI != null) { LockUI.SetActive(true); }
            Image s = GetComponent<Image>();
            Color temp = s.color;
            temp.a = .4f;
            s.color = temp;
        }
        starsNeeded =  StarsToUnlockLevel - totalStarsGained;
     }

    private void MenuUISFX() { FindObjectOfType<AudioManager>().Play("MenuSelectUI"); }

    public void HowToPlay()
    {
        if(HowToPlayUI != null) HowToPlayUI.SetActive(true);
    }
    public void HowToPlay_OK()
    {
        if (HowToPlayUI != null) HowToPlayUI.SetActive(false);
    }
    
}