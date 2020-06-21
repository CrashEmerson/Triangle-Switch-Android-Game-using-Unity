using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Options : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI MusicSwitch;
    [SerializeField] GameObject ResetDataUI;
    bool switchStatus;
    string music = "MUSIC ";
    
    private void Start()
    {
        if (PlayerPrefs.GetString("Music") == "true") { switchStatus = true; }
        else if (PlayerPrefs.GetString("Music") == "false") { switchStatus = false; }
        
        SwitchONOFF();
    }
    public void SwitchONOFF()
    {
        if (switchStatus == true)
        {
            MusicSwitch.text = music + "ON";
            PlayerData.SwitchMusic("true");
            FindObjectOfType<AudioManager>().Play("IntroGameTheme");
            switchStatus = false;
        }
        else if(switchStatus == false)
        {
            MusicSwitch.text = music + "OFF";
            PlayerData.SwitchMusic("false");
            FindObjectOfType<AudioManager>().Stop("IntroGameTheme");
            switchStatus = true;

        }
    }
    public void ResetData()
    {
        PlayerData.ResetAllData();
        PlayerData.SwitchMusic("true");
        ResetDataUI.SetActive(true);
    }
    public void SetSwitchStatusON() { switchStatus = true; }
    public void SetSwitchStatusOFF() { switchStatus = false; }
}
