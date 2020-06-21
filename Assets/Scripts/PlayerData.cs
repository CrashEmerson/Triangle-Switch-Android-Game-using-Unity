using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerData
{
    public static void SaveStarData(string levelname,string stagename,int starCount) // stars Count
    {
        PlayerPrefs.SetInt(levelname + stagename + "star", starCount);
    }
    public static int LoadStarData(string levelname,string stagename)
    {
        return PlayerPrefs.GetInt(levelname + stagename + "star");
    }

    public static void SaveLevelCompleted(string levelname, string stagename) // Checksum level completed
    {
        PlayerPrefs.SetString(levelname + stagename, "completed"); // Ex : Level01Lantern = completed
    }
    public static string CheckLevelIsCompleted(string levelname, string stagename)
    {
        return PlayerPrefs.GetString(levelname + stagename);
    }


    // Reset all saved Data
    public static void ResetAllData()
    {
        PlayerPrefs.DeleteAll();
    }
    
    //Music ON/OFF
    public static void SwitchMusic(string value)
    {
        PlayerPrefs.SetString("Music",value);
    }
}
