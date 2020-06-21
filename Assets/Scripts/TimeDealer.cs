using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimeDealer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI counter;

    [SerializeField] GameObject GameOverCanvas;
    [SerializeField] TextMeshProUGUI GameOverMessage;
    [SerializeField] LevelScript Level;
    Animator anim;
    private float timer;

    int laternCount;

    bool canUpdateTimer;
    private void Start()
    {
        canUpdateTimer = true;
        laternCount = Level.GetlanternCount();
        timer = Level.GetLevelFinishTime();
        anim = counter.GetComponent<Animator>();
        FindObjectOfType<AudioManager>().Play("ClockTick");
    }
    private void FixedUpdate()
    {
        if(GameOverCanvas != null) if (GameOverCanvas.activeSelf == true) { Destroy(gameObject); }
        if (canUpdateTimer == true) { TimeReverseCounter(); }
    }

    void TimeReverseCounter()
    {
        if (timer >= 0f)
        {
            timer = timer - Time.deltaTime;
            if (counter != null)
            {
                counter.text = Convert.ToInt32(timer).ToString();
            }
        }if (timer <= 3) { counter.color = Color.red; }
        if (timer <= 0)
        {
            ShowGameOverCanvas();
        }
    }

    void ShowGameOverCanvas()
    {
        FindObjectOfType<AudioManager>().Stop("ClockTick");
        FindObjectOfType<AudioManager>().Play("GameOverSFX");
        GameOverMessage.text = "Times UP !!";
        GameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }
    public void StopTimer()
    {
        canUpdateTimer = false;
    }
}