using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDealer : MonoBehaviour
{
    [SerializeField] LevelScript level;
    [SerializeField] GameObject LevelCompleteCanvas;
    [SerializeField] GameObject PauseCanvas;
    [SerializeField] GameObject JoystickCanvas;
    [HideInInspector] public int laternCount;
    TimeDealer timeDealer;
    LanternScript lanternScript;
    FireBallDealer fireBallDealer;

    private void Start()
    {
        lanternScript = FindObjectOfType<LanternScript>();
        timeDealer = FindObjectOfType<TimeDealer>();
        fireBallDealer = FindObjectOfType<FireBallDealer>();
        GetLanternCounts();
    }
    private void Update()
    {
        if (laternCount == 1)
            if (lanternScript != null)
                if (lanternScript.GetComponent<SpriteRenderer>().sprite.name == "Lantern2_0")
                if (timeDealer != null)
                    {
                        timeDealer.StopTimer();
                        fireBallDealer.StopSpawnFireBall();
                    }
                
    }

    void GetLanternCounts()
    {
       laternCount = level.GetlanternCount();
    }

    public void DecreaseLaternCount()
    {
        if(laternCount > 0)
        {
            laternCount--;
        }
        if(laternCount == 0)
        {
            if(timeDealer != null ) timeDealer.StopTimer();
            PlayerData.SaveLevelCompleted(level.name, level.GetStageName());
            Destroy(FindObjectOfType<FireBallDealer>());
            StartCoroutine(ShowLevelCompleteCanvas());
        }
    }

    IEnumerator ShowLevelCompleteCanvas()
    {
        yield return new WaitForSeconds(1.5f);
        FindObjectOfType<AudioManager>().Stop("GamePlayTheme");
        FindObjectOfType<AudioManager>().Stop("ClockTick");
        FindObjectOfType<AudioManager>().Play("LevelCompletedSFX");
        PauseCanvas.SetActive(false);
        JoystickCanvas.SetActive(false);
        LevelCompleteCanvas.SetActive(true);
    }
    
}