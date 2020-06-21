using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour
{
    [SerializeField] int levelNumber;
    [SerializeField] LevelScript level;
    [SerializeField] Sprite[] LevelLockSprite; // 0 -> Normal  1 -> Light
    [SerializeField] GameObject[] Stars;
    [SerializeField] GameObject Lock;
    [SerializeField] GameObject LevelLockUI;
    
    Image image;
    string CheckSumIsLevelCompleted; 
    int ObtainedLevelStars;
    private void Start()
    {
        if (level != null) ObtainedLevelStars =  PlayerData.LoadStarData(level.name,level.GetStageName());
        if (level != null) CheckSumIsLevelCompleted = PlayerData.CheckLevelIsCompleted(level.name, level.GetStageName());
        image = GetComponent<Image>();
    }
    private void Update()
    {
        loadScript();
    }

    public void loadLevel()
    {
        if (Lock.activeSelf == false)
        {
            FindObjectOfType<AudioManager>().Play("LevelSelectUI");
            SceneManager.LoadScene(levelNumber);
        }
        else LevelLockUI.SetActive(true);
    }

    void loadScript()
    {
        if(CheckSumIsLevelCompleted == "completed")
        {
            image.sprite = LevelLockSprite[1]; // 1 -> Light
            StarsSprite();
            Lock.SetActive(false);
        }else if(CheckPreviousLevelIsCompleted() == false)
        {
            image.sprite = LevelLockSprite[0];
            Lock.SetActive(true);
        }
        else
        {
            image.sprite = LevelLockSprite[0]; // 0 -> Normal
            Lock.SetActive(false);
        }
    }
    void StarsSprite()
    {
        if (Stars != null)
        {
            Stars[0].SetActive(true);
            Stars[1].SetActive(true);
            Stars[2].SetActive(true);
            if (ObtainedLevelStars == 0)
            {
                Stars[0].GetComponent<Image>().color = Color.black;
                Stars[1].GetComponent<Image>().color = Color.black;
                Stars[2].GetComponent<Image>().color = Color.black;
            }
            if (ObtainedLevelStars == 1)
            {
                Stars[0].GetComponent<Image>().color = Color.white;
                Stars[1].GetComponent<Image>().color = Color.black;
                Stars[2].GetComponent<Image>().color = Color.black;
            }
            if (ObtainedLevelStars == 2)
            {
                Stars[0].GetComponent<Image>().color = Color.white;
                Stars[1].GetComponent<Image>().color = Color.black;
                Stars[2].GetComponent<Image>().color = Color.white;
            }
            if (ObtainedLevelStars == 3)
            {
                Stars[0].GetComponent<Image>().color = Color.white;
                Stars[1].GetComponent<Image>().color = Color.white;
                Stars[2].GetComponent<Image>().color = Color.white;
            }
        }
    }
    bool CheckPreviousLevelIsCompleted()
    {
        string levelname = level.name; // curent level name
        string stagename = level.GetStageName();
        
        if (levelname == "Level01") return true;
        int num = int.Parse(levelname.Substring(5, 2));
        string previousLevelname = "Level0" + (num - 1); // previous level name

        if (PlayerData.CheckLevelIsCompleted(previousLevelname, stagename) == "completed")
            return true;
       else return false;
    }
}
